using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class WordSpawner : Singleton<WordSpawner>
{
    public enum SpawnState { SPAWNING, WATTING, COUNTING };

    WordManager wordManager;

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public int amount;
        public float rate;
    }

    public Wave waves;

    [Header("Wave Properties")]
    public int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDown = 0f;

    //private float searchCountDown;

    public SpawnState state = SpawnState.COUNTING;

    public TextMeshProUGUI waveInfo;
    public CanvasGroup waveInfoGroup;

    private void Start()
    {
        wordManager = GetComponent<WordManager>();
        waveCountDown = timeBetweenWaves;
    }

    public SpawnState GetCurrentState()
    {
        return state;
    }

    void Update()
    {
        #region old spawn
        /*
        if(this.transform.position.z <= zombieSpawnPoint.position.z)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Random.Range(minDistance, maxDistance));

            wordManager.AddWord();
        }
        */
        #endregion

        if (GameManager.instance.gameStared)
        {
            if(state == SpawnState.WATTING)
            {
                //check if enemy alive
                if (!IsEnemyAlive())
                {
                    // start new wave;
                    WaveCompleted();
                }
                else
                {
                    return;
                }
            }


            if(waveCountDown <= 0)
            {
                if(state != SpawnState.SPAWNING)
                {
                    //Start spawning
                    StartCoroutine(SpawnWave(waves));
                }
                else
                {
                    waveInfo.rectTransform.DOAnchorPos(new Vector2(0f, -250f), 1f, true);
                    waveInfoGroup.DOFade(0, 0.7f);
                }
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }

            //if(state == SpawnState.COUNTING)
            //{
                
            //}
            //else if (state == SpawnState.SPAWNING)
            //{
            //    waveInfo.rectTransform.DOAnchorPos(new Vector2(0f,-250f), 1f, true);
            //    waveInfoGroup.DOFade(0, 0.7f);

            //}

        }

    }

    void ShowWaveInfo()
    {
        waveInfo.text = string.Format("<u>Wave {0} cleared</u>\n<size=30> Score : {1}", nextWave.ToString("000"),WordManager.instance.score.ToString("00000"));

        waveInfo.rectTransform.DOAnchorPos(Vector2.zero, 1f, true);

        waveInfoGroup.DOFade(1, 0.7f).SetEase(Ease.OutBack);
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;
        nextWave++;
#if UNITY_EDITOR
        Debug.Log("Wave Pass + Increase level");
#endif
        PlayerController.endWave = true;

        ShowWaveInfo();

        //Increase difficulty
        waves.amount += 2;
        waves.waveName = "Wave " + nextWave;
        //waves.rate += .2f;
    }

    bool IsEnemyAlive()
    {
        //searchCountDown -= Time.deltaTime;

        //if(searchCountDown <= 0f)
        //{
        //    searchCountDown = 1f;
        //    //if (GameObject.FindGameObjectWithTag("ZombieHit") == null && GameObject.FindGameObjectWithTag("Zombies") == null)
        //    //{
        //    //    return false;
        //    //}

        //}
        if(wordManager.wordList.Count <= 0)
        {
            return false;
        }

        return true;
    }


    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;
        
        for (int i = 0; i < _wave.amount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        PlayerController.endWave = false;

        state = SpawnState.WATTING;

        yield break;
    }


    void SpawnEnemy()
    {
        wordManager.AddWord();
        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + Random.Range(-10f, 10f));
    }
}

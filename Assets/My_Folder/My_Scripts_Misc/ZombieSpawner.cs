using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    WordDisplay wordDisplay;

    public ObjectPooler zombiePooler;

    public Transform spawnPoint;
    public float distance;
    /*
    void SpawnEnemy(GameObject _Enemy)
    {
        GameObject zombieObj = Instantiate(_Enemy);

        Transform[] children = zombieObj.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            if (child.CompareTag("Canvas"))
            {
                //Debug.Log(child.GetChild(0).name);

                text = child.GetComponentInChildren<TMPro.TextMeshProUGUI>();

                text.text = "Nghia Dep Trai Vcl";
            }
        }
    */

    public WordDisplay SpawnEnemy(GameObject _Enemy)
    {
        
        //GameObject zombieObj = Instantiate(_Enemy);
        Vector3 sp = new Vector3(spawnPoint.position.x + Random.Range(-distance, distance), 0.5f, spawnPoint.position.z);

        //GameObject zombieObj = ObjectPooling.instance.GetObjectFromPool("Zombie", sp, Quaternion.Euler(new Vector3(0,-180,0)));

        GameObject zombieObj = zombiePooler.GetPooledObject();

        zombieObj.transform.position = sp;

        zombieObj.SetActive(true);

        Transform[] children = zombieObj.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            if (child.CompareTag("Canvas"))
            {
                //Debug.Log(child.GetChild(0).name);

                wordDisplay = child.GetComponentInChildren<WordDisplay>();
                
            }
        }

        return wordDisplay;
    }
}

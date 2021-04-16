using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WordDisplay : MonoBehaviour
{

    public TMPro.TextMeshProUGUI text;

    public Image image;

    public EnemyMovement enemy;

    public void SetWord(string _word)
    {
        text.text = _word;
        image.color = new Color32(79, 79, 79, 20);

        enemy.Live();
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);


        text.color = new Color32(255, 128, 0, 255);
        image.color = new Color32(79, 79, 79, 200);

        //WordManager.instance.target.position = this.transform.position + new Vector3(0f,-2f,0f);

        WordManager.instance.SetTargetPoint(this.transform.position , new Vector3(0f, -2f, 2f));

        //GetTargetTag();
    }

    public void RemoveWord()
    {
        //Destroy(gameObject);

        text.text = "";
        text.color = Color.white;
        image.color = new Color32(79, 79, 79, 0);

        //active ragdoll on the zombies

        enemy.Die();
    }


    //private void OnDestroy()
    //{
    //    Transform[] parents = GetComponentsInParent<Transform>();

    //    foreach (Transform par in parents)
    //    {
    //        if (par.CompareTag("ZombieHit"))
    //        {
    //            Destroy(par.gameObject);
    //        }
    //    }

    //}


    //public void GetTargetTag()
    //{

    //    Transform[] parents = GetComponentsInParent<Transform>();

    //    foreach (Transform par in parents)
    //    {
    //        if (par.CompareTag("Zombies"))
    //        {
    //            par.tag = "ZombieHit";
    //        }
    //    }

    //}

}

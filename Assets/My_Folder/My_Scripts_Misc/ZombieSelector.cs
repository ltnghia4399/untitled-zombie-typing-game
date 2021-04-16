using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSelector : MonoBehaviour
{
    private void Start()
    {
        
        int rand = Random.Range(1, this.transform.childCount);

        this.transform.GetChild(rand).gameObject.SetActive(true);
        
    }
}

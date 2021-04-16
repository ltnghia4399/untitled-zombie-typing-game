using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awake : Singleton<awake>
{
    new void Awake()
    {
        Debug.Log("hello");
    }
}

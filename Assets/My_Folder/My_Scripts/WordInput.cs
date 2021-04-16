using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WordInput : MonoBehaviour
{
    public WordManager wordManager;

    void Update()
    {
        if (!PlayerGunPrep.isPrep)
        {
            foreach (char letter in Input.inputString)
            {
                char l = Char.ToLower(letter);
                wordManager.TypeLetter(l);
                //Debug.Log(l);
            }
        }

    }
}

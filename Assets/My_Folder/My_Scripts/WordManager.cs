using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My_UtilityScript;
public class WordManager : Singleton<WordManager>
{

    public List<Word> wordList;

    bool hasActiveWord;

    Word activeWord;

    public ZombieSpawner zombieSpawner;

    public GameObject zombiePrefab;

    public Transform target;

    [HideInInspector]
    public int score;

    public void AddWord()
    {
        //Word word = new Word(WordsGenerator.GetRandomWords(), zombieSpawner.SpawnEnemy(zombiePrefab));

        Word word = new Word(WordsGenerator.GetWord(), zombieSpawner.SpawnEnemy(zombiePrefab));
#if UNITY_EDITOR
        Debug.Log(word.word);
#endif
        wordList.Add(word);
    }

    public void SetTargetPoint(Vector3 postion,Vector3 offset)
    {
        target.position = postion + offset;
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter(); // get next letter in the sequence & remove the letter just typed

                PlayerController.isFire = true; // Player start shooting

                //Increase score here ?
                score++;
            }
            else
            {
                //Wrong typed sound 
                AudioManager.instance.PlayWithoutRandomPitch("Stuck");
            }
        }
        else
        {
            //check the input letter are first letter of the word ?
            foreach (Word word in wordList)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    score++;
                    PlayerController.isFire = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        //if typed out the word _ then remove the word out of the list
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            wordList.Remove(activeWord);
            
        }
    }

}

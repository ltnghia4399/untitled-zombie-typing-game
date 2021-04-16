using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class WordsGenerator : MonoBehaviour
{
    //const string filePath = "Assets/My_Folder/TextFile/TextFile.txt";

    string filePath;

    public TextAsset textFile;

    private static string[] wordsArray = { "walk"
,"branch"
,"clap"
,"balance"
,"replace"
,"judge"
,"scrape"
,"soak"
,"shrug"
,"drop"
,"screw"
,"bubble"
,"stare"
,"tempt"
,"tug"
,"moor"
,"avoid"
,"signal"
,"sparkle"
,"hammer"
,"book"
,"talk"
,"wave"
,"peep"
,"drag"
,"beg"
,"possess"
,"slow"
,"expect"
,"protect"
,"scribble"
,"dress"
,"bump"
,"squash"
,"look"
,"laugh"
,"wrap"
,"whirl"
,"rain"
,"harass"
,"obey"
,"fetch"
,"approve"
,"waste"
,"close"
,"squeeze"
,"remove"
,"wink"
,"question"
,"suggest"
    };

    //Assets/My_Folder/Resources
    private static List<string> wordLoader = new List<string>();

    static int wordIndex = -1;

    //List<string> words = new List<string>();
    //string[] s;
    //public static List<string> wo = new List<string>();


    private void Awake()
    {


        //filePath = "textfile.txt";

        filePath = "Assets/My_Folder/Resources/TextFile.txt";

        ReadFile(filePath);

        Shuffle(wordLoader);

        //readfiletext(filepath);

#if UNITY_EDITOR
        foreach (var item in wordsArray)
        {
            Debug.Log(item);
        }
#endif
    }


    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Return))
    //    {
    //        Debug.Log(wordIndex + " " +GetWord());

    //    }
    //}

    //void ReadFileText(string _filePath)
    //{
    //    words = File.ReadAllLines(_filePath).ToList();

    //    foreach (var item in words)
    //    {
    //        s = item.Split(' ');

    //        foreach (var w in s)
    //        {
    //            wo.Add(w.ToString());
    //        }
    //    }

    //}

    public static string GetWord()
    {

#if UNITY_WEBGL
        if (wordIndex == wordsArray.Length - 1)
        {
            wordIndex = 0;
        }
        else
        {
            wordIndex++;
        }

        return wordsArray[wordIndex];
#endif
        if (wordIndex == wordLoader.Count - 1)
        {
            wordIndex = 0;
        }
        else
        {
            wordIndex++;
        }

        return wordLoader[wordIndex];
    }

#if UNITY_WEBGL
    void ShuffleArray(string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            int rand = Random.Range(i, list.Length);
            string tempWord = list[i];

            list[i] = list[rand];
            list[rand] = tempWord;
        }
    }
#endif

    void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            string tempWord = list[i];

            list[i] = list[rand];
            list[rand] = tempWord;
        }
    }

    void ReadFile(string _filePath)
    {
        //var textFile = Resources.Load<TextAsset>("TextFile");

        //wordLoader = textFile.text.Split('\n').ToList();

        StreamReader sr = new StreamReader(_filePath);

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            wordLoader.Add(line);
        }

        sr.Close();
    }

    //public static string GetRandomWords()
    //{
    //    int wordIndex = Random.Range(0, wordLoader.Count);

    //    string randWord = wordLoader[wordIndex];

    //    return randWord;
    //}


}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M : MonoBehaviour
{
    public static M instance;

    public string username;
    public int score;
    public string bestuser;
    public int bestscore;



    private void Awake()
    {
        if (instance != null) { Destroy(gameObject);return; }

        instance = this;
        LoadViaJson();
        DontDestroyOnLoad(gameObject);
        
    }

    [System.Serializable]struct Highscore { public string newbestuser;public int newbestscore;public string lastuser; }

    public void SaveViaJson()
    {
        Highscore newhighscore = new Highscore();
        newhighscore.newbestscore = bestscore; newhighscore.newbestuser = bestuser; newhighscore.lastuser = username;
        string json = JsonUtility.ToJson(newhighscore);
        File.WriteAllText(Application.persistentDataPath + "/savehighscore.json", json);
    }
    public void LoadViaJson()
    {
        string path = Application.persistentDataPath + "/savehighscore.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            
            Highscore load = JsonUtility.FromJson<Highscore>(json);
            bestuser = load.newbestuser; bestscore = load.newbestscore; username = load.lastuser;
        }

    }

}

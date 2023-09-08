using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField Username;
    public Button Start_button, End_button;
    // Start is called before the first frame update
    void Start()
    {
        Username.text = M.instance.username;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveUsername()
    {
        string temp = Username.text;
        M.instance.username = temp;
    }
    public void StartMethod()
    {
        SaveUsername();
        SceneManager.LoadScene("main");
    }

    public void onClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        M.instance.SaveViaJson();
        Application.Quit();
    }
    
}

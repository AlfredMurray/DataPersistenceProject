using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TMP_InputField enterNameField;
    public TMP_Text bestScore;
 
    void Start()
    {
        NameManager.Instance.LoadScore(-50);
        if (NameManager.Instance != null)
        {
            if (NameManager.Instance.score == -100) bestScore.text = "Best Score: ";
            else bestScore.text = "Best Score: " + NameManager.Instance.nameToSet + " (" + NameManager.Instance.score + ")";
        }
    }

    void Update()
    {
        
    }

    public void GetName()
    {
        NameManager.Instance.playerName = enterNameField.text;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}

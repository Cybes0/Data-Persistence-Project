using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuUIHandlerX : MonoBehaviour
{
    // public string enterName;
    [SerializeField] private TMP_InputField inputText;

    public int highScore = 0;    
    public Text Highscore;

    private void Start()
    {
        LoadHighscore();
        DisplayHighscore();
    }

    public void StartMain()
    {        
        SceneManager.LoadScene(1);
    }

    public void EnterName()
    {
        DataManagerX.userName = inputText.text;        
        Debug.Log(DataManagerX.userName);
    }

    public void Quit()
    {        
#if (UNITY_EDITOR)
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    [System.Serializable]
    class PlayerHighscore
    {
        public string name;
        public int score;
    }

    private PlayerHighscore LoadHighscore()
    {
        PlayerHighscore data = new PlayerHighscore
        {
            name = "None",
            score = 0
        };
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerHighscore saved_data = JsonUtility.FromJson<PlayerHighscore>(json);

            highScore = saved_data.score;
            data = saved_data;
        }
        return data;
    }

    public void DisplayHighscore()
    {
        PlayerHighscore data = LoadHighscore();
        Highscore.text = "Best Score : " + data.name + " : " + data.score;
    }
}

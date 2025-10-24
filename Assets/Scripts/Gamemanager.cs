using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;



public class Jsonfilemanager
{
    public int highscore, score;

    public void filefinder()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            Jsonfilemanager data = JsonUtility.FromJson<Jsonfilemanager>(json);
            SaveScore(data);
        }
        else
        {
            Debug.LogWarning("No save file found");
            System.IO.File.Create(path);
            filefinder();
        }
    }

    public void SaveScore(Jsonfilemanager data)
    {
        if (score > highscore)
        {
         data.highscore = score;
        }

    }
}


    public class Gamemanager : MonoBehaviour
{

    public GameState m_currentState;
    public int score, highScore;
    public Jsonfilemanager jsonfilemanager;
    bool doOnce = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    void Start()
    {
        jsonfilemanager = new Jsonfilemanager();
    }

    void Update()
    {
        switch (m_currentState)
        {

            case GameState.MainMenu:
                // Handle main menu logic
                break;
            case GameState.Playing:
                // Handle gameplay logic
                break;
            case GameState.Paused:
                // Handle paused logic
                break;
            case GameState.GameOver:
                // Handle game over logic
                if (!doOnce)
                {
                    jsonfilemanager.filefinder();
                    doOnce = true;
                }
                break;

        }
    }

        // Update is called once per frame
    }

using System;
using System.Collections;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[Serializable]
public class PlayerData
{
    public int highscore;
    public string path;
    public int score;
}

public class Jsonfilemanager
{


    public bool filefinder(PlayerData data)
    {
        if (System.IO.File.Exists(data.path))
        {
            Debug.Log("File found at" + data.path);
            return true;
        }
        else
        {
            Debug.LogWarning("File not found at" + data.path);
            return false;
        }

    }

    public void LoadScore(PlayerData data)
    {
        if (filefinder(data))
        {
            string filecontents = System.IO.File.ReadAllText(data.path);
            var loadedData = JsonUtility.FromJson<PlayerData>(filecontents);
            if (loadedData != null)
            {
                data.highscore = loadedData.highscore;
            }
            
        }
    }

    public void SaveScore(PlayerData data)
    {
        if (data.score > data.highscore && filefinder(data))
        {
            data.highscore = data.score;
            Debug.Log("New Highscore: " + data.highscore);
            string filecontents = JsonUtility.ToJson(data, true);
            System.IO.File.WriteAllText(data.path, filecontents);
            Debug.Log("Saved");
        }
    }
}


public class Gamemanager : MonoBehaviour
{

    public GameState m_currentState;
    public int playerScore;
    public GameObject[] Menus;
    public Jsonfilemanager jsonfilemanager;
    public float timer = 0.2f;
    public PlayerData playerData;
    public bool[] doOnce;
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
        playerData.path = Application.persistentDataPath + "/savefile.txt";
        if (!System.IO.File.Exists(playerData.path))
        {
            playerData = new PlayerData();
            Debug.LogWarning("No save file found");
            System.IO.File.Create(playerData.path);
        }
        else
        {
            jsonfilemanager.LoadScore(playerData);
        }

    }
    void Update()
    {
        switch (m_currentState)
        {

            case GameState.MainMenu:
                // Handle main menu logic
                if (!doOnce[0])
                {
                    Instantiate(Menus[0]);
                    doOnce[0] = true;
                }
                Debug.Log("Main Menu");
                break;
            case GameState.Playing:
                // Handle playing logic
                if (!doOnce[1])
                {
                    Time.timeScale = 1f;
                    doOnce[1] = true;
                    StartCoroutine(Scoring());
                    clearMenus();
                }
                Debug.Log("Playing");
                break;
            case GameState.Paused:
                // Handle paused logic
                if (doOnce[2])
                {
                    StopAllCoroutines();
                    Time.timeScale = 0f;
                    doOnce[2] = false;
                }
                Debug.Log("Paused");

                break;
            case GameState.GameOver:
                // Handle game over logic
                if (!doOnce[3])
                {
                    StopAllCoroutines();
                    playerData.score = playerScore;
                    Instantiate(Menus[2]);
                    jsonfilemanager.SaveScore(playerData);
                    doOnce[3] = true;
                }
                Debug.Log("Game Over");
                break;

        }
    }

    IEnumerator Scoring()
    {
        while (m_currentState == GameState.Playing)
        {
            yield return new WaitForSeconds(timer);
            playerScore++;
            Debug.Log("Score: " + playerScore);
        }
    }
    // Update is called once per frame


    void clearMenus()
    {
        for (int i = 0; i < Menus.Length; i++)
        {
            Destroy(GameObject.FindWithTag("Menu"));

        }
    }
}


using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Inputs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI scoreText, highScoreText;
    public Gamemanager GameManager;
    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
        PlayerData data = GameManager.playerData;
    }


    public void Mainmenu()
    {
      SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame()
    {
        GameManager.m_currentState = Gamemanager.GameState.Playing;
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

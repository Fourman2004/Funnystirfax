using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Inputs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI scoreText, highScoreText;
    public Gamemanager GameManager;
    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
        PlayerData data = GameManager.playerData;
    }


    public void Mainmenu()
    {
        GameManager.m_currentState = Gamemanager.GameState.MainMenu;
        Instantiate(Player, Vector3.zero, Quaternion.identity);
        Destroy(gameObject);
    }

    public void ResumeGame()
    {
        GameManager.m_currentState = Gamemanager.GameState.Playing;
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    public void PlayGame()
    {
        GameManager.m_currentState = Gamemanager.GameState.Playing;
        Instantiate(Player, Vector3.zero, Quaternion.identity);
        Destroy(gameObject);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Inputs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI scoreText, highScoreText;
    Gamemanager GameManager;

    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
        PlayerData data = GameManager.playerData;
    }


    public void Mainmenu()
    {
        GameManager.m_currentState = Gamemanager.GameState.MainMenu;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null)
        {
            Instantiate(Player, Vector3.zero, Quaternion.identity);
        }
    }

    public void PlayGame()
    {
        GameManager.m_currentState = Gamemanager.GameState.Playing;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null)
        {
            Instantiate(Player, Vector3.zero, Quaternion.identity);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

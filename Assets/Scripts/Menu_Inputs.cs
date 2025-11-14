using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Inputs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI scoreText, highScoreText;

    void Start()
    {
        Gamemanager GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
        PlayerData data = GameManager.playerData;
        scoreText.text = "Score: " + data.score;
        highScoreText.text = "Highscore: " + data.highscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

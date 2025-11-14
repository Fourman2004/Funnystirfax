using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleMove : MonoBehaviour
{

    Rigidbody rb, player_rb;
    public float movement;
    public int points;
    GameObject player, gameManager;
    Gamemanager GM;
    EnemySpawn enemySpawn;
    public bool isSpaceCraft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        GM = gameManager.GetComponent<Gamemanager>();
        rb = GetComponent<Rigidbody>();
        if (GM.m_currentState != Gamemanager.GameState.GameOver)
        {
            player = GameObject.FindWithTag("Player");
            player_rb = player.GetComponent<Rigidbody>();
            enemySpawn = GameObject.FindWithTag("Spawner").GetComponent<EnemySpawn>();
            rb.linearVelocity = transform.forward * movement;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpaceCraft && GM.m_currentState != Gamemanager.GameState.GameOver)
        {
            Vector3 pos = Vector3.zero;
            pos.x = player_rb.linearVelocity.x;
            pos.y = player_rb.linearVelocity.y;
            rb.linearVelocity = pos * movement;
        }
    }

    private void OnDestroy()
    {
        if (GM.m_currentState == Gamemanager.GameState.Playing)
        {
            if (gameObject.CompareTag("Asteroid"))
            {
                enemySpawn.obstacleamount--;

            }
            else
            {
                enemySpawn.shipamount--;
            }
        }
    }
}

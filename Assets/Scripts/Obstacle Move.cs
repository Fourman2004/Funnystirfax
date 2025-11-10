using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleMove : MonoBehaviour
{

    Rigidbody rb;
    public float movement;
    public int points;
    GameObject player, gameManager;
    Gamemanager GM;
    EnemySpawn enemySpawn;
    public bool isSpaceCraft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindWithTag("GameManager");
        GM = gameManager.GetComponent<Gamemanager>();
        player = GameObject.FindWithTag("Player");
        enemySpawn = GameObject.FindWithTag("Spawner").GetComponent<EnemySpawn>();
        rb.linearVelocity = transform.forward * movement;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody player_rb = player.GetComponent<Rigidbody>();
        if (isSpaceCraft)
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
            enemySpawn.obstacleamount--;
        }
    }
}

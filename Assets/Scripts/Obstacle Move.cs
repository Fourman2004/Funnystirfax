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
        if (isSpaceCraft)
        {
            Vector3 pos = Vector3.zero;
            pos.x = player.transform.position.x;
            pos.y = player.transform.position.y;
            pos.z = transform.forward.z;
            rb.linearVelocity = new Vector3(pos.x,pos.y,(pos.z*movement));
        }
        else
        {

            rb.linearVelocity = transform.forward * movement;
        }
    }

    private void OnDestroy()
    {
        if (GM.m_currentState == Gamemanager.GameState.Playing)
        {
            GM.playerScore += points;
            enemySpawn.obstacleamount--;
        }
    }
}

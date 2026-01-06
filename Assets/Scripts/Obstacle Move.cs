using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleMove : MonoBehaviour
{

    Rigidbody rb, player_rb;
    public float movement;
    public int points;
    GameObject player, gameManager;
    public GameObject explosionSFX;
    Gamemanager GM;
    AudioManager audioManager;
    EnemySpawn enemySpawn;
    public bool isSpaceCraft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        gameManager = GameObject.FindWithTag("GameManager");
        GM = gameManager.GetComponent<Gamemanager>();
        rb = GetComponent<Rigidbody>();
        if (GM.m_currentState != Gamemanager.GameState.GameOver)
        {
            player = GameObject.FindWithTag("Player");
            player_rb = player.GetComponent<Rigidbody>();
            enemySpawn = GameObject.FindWithTag("Spawner").GetComponent<EnemySpawn>();
            rb.linearVelocity = transform.forward * (movement * (GM.playerScore / 2));
            StartCoroutine(Takentoolong(10));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpaceCraft && GM.m_currentState != Gamemanager.GameState.GameOver)
        {
            StopCoroutine(Takentoolong(10));
            Vector3 pos = Vector3.zero;
            pos.x = player_rb.linearVelocity.x;
            pos.y = player_rb.linearVelocity.y;
            rb.linearVelocity = pos * (movement * MathF.Truncate(GM.playerScore/10 * 0.75f));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GM.m_currentState == Gamemanager.GameState.Playing)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (GM.m_currentState == Gamemanager.GameState.Playing || GM.m_currentState == Gamemanager.GameState.MainMenu)
        {
            if (gameObject.CompareTag("Asteroid"))
            {
                enemySpawn.obstacleamount--;

            }
            else
            {
                GameObject Explosion = Instantiate(explosionSFX, this.transform.position, this.transform.rotation);
                StartCoroutine(Takentoolong(Explosion, 2));
                audioManager.PlaySFX(1);
                enemySpawn.shipamount--;
            }
        }
    }

    IEnumerator Takentoolong(GameObject Explosion, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(Explosion);
    }

    IEnumerator Takentoolong(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class ship_Shoot : MonoBehaviour
{
    GameObject target;
    public float shootTimer;
    Player_Controls Player_Controls;
    Gamemanager GM;
    AudioManager audioManager;
    public GameObject projectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        target = GameObject.FindWithTag("Player");
        GM = GameObject.FindWithTag("GameManager").GetComponent<Gamemanager>();
        Player_Controls = target.GetComponent<Player_Controls>();
        StartCoroutine(ShootCoroutine(shootTimer));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShootCoroutine(float timer)
    {
        while (GM.m_currentState == Gamemanager.GameState.Playing)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1,timer));
            Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.localPosition.z + -10), new Quaternion(90, 0, 0, 100));
            audioManager.PlaySFX(UnityEngine.Random.Range(3,6));
        }

    }
}
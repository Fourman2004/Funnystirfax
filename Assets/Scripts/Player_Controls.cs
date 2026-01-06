using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Player_Controls : MonoBehaviour
{

    public float speed, distance;
    bool doOnce;
    public Rigidbody rb;
    public InputActionAsset playerControlMap;
    public GameObject projectile, explosionSFX;
    Gamemanager Gamestate;
    AudioManager audioManager;
    [NonSerialized]
    public InputAction move, attack, pause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Gamestate = GameObject.FindWithTag("GameManager").GetComponent<Gamemanager>();
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        playerControlMap.Enable();
        move = playerControlMap.FindActionMap("Player").FindAction("Move");
        attack = playerControlMap.FindActionMap("Player").FindAction("Attack");
        pause = playerControlMap.FindActionMap("Player").FindAction("Pause");
    }

    // Update is called once per frame
    public void Move(Vector2 direction)
    {
        Vector3 direction3 = new Vector3(direction.x, direction.y, 0);
        Debug.Log("move");
        rb.AddForce(direction3 * (speed * (Gamestate.playerScore * 0.75f)));
    }

    void Attack(float isattacking, GameObject Projectile)
    {
        Debug.Log("attack");
        if (isattacking != 0 && !doOnce)
        {
            Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, transform.localPosition.z + distance), new Quaternion(90, 0, 0, 100));
            doOnce = true;
            audioManager.PlaySFX(0);
        }
    }

    //[System.Obsolete]
    public void FixedUpdate()
    {

        switch (!playerControlMap.IsUnityNull() && playerControlMap.enabled)
        {
            case true when move.ReadValue<Vector2>() != Vector2.zero:
                Move(move.ReadValue<Vector2>());
                break;
            case true when attack.ReadValue<float>() != 0:
                Attack(attack.ReadValue<float>(), projectile);
                break;
            case true when pause.ReadValue<float>() != 0:
                Gamemanager Gamestate = GameObject.FindWithTag("GameManager").GetComponent<Gamemanager>();
                Gamestate.m_currentState = Gamemanager.GameState.Paused;
                break;
            default:
                rb.linearVelocity = Vector3.zero;
                doOnce = false;
                break;
        }


    }

    public void OnDestroy()
    {
        GameObject Explosion = Instantiate(explosionSFX, this.transform.position, this.transform.rotation);
        StartCoroutine(Takentoolong(Explosion, 2));
        Gamestate.m_currentState = Gamemanager.GameState.GameOver;
        this.enabled = false;
        audioManager.PlaySFX(2);
    }

    IEnumerator Takentoolong(GameObject Explosion, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(Explosion);
    }
}

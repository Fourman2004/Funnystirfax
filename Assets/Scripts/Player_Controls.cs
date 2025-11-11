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
    public GameObject projectile;
    [NonSerialized]
    public InputAction move, attack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerControlMap.Enable();
        move = playerControlMap.FindActionMap("Player").FindAction("Move");
        attack = playerControlMap.FindActionMap("Player").FindAction("Attack");
    }

    // Update is called once per frame
    public void Move(Vector2 direction)
    { 
        Vector3 direction3 = new Vector3(direction.x, direction.y, 0);
        Debug.Log("move");
        rb.AddForce(direction3 * speed);
    }

     void Attack(float isattacking, GameObject Projectile) {
        Debug.Log("attack");
        if (isattacking != 0 && !doOnce) {
            Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, transform.localPosition.z + distance), Quaternion.identity);
            doOnce = true;
        }
    }

    //[System.Obsolete]
    public void FixedUpdate()
    {

        switch (!playerControlMap.IsUnityNull())
        {
            case true when move.ReadValue<Vector2>() != Vector2.zero:
                Move(move.ReadValue<Vector2>());
                break;
            case true when attack.ReadValue<float>() != 0:
                Attack(attack.ReadValue<float>(), projectile);
                break;
            default:
                rb.linearVelocity = Vector3.zero;
                doOnce = false;
                break;
        }


    }
}

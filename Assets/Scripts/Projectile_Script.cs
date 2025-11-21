using System.Collections;
using UnityEngine;

public class Projectile_Script : MonoBehaviour
{

    public Rigidbody rb;
    public float projectileSpeed, delay;
    public string IgnoreTag;
    Gamemanager GM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<Gamemanager>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0,0,transform.forward.z) * (projectileSpeed*(GM.playerScore/10)));
        StartCoroutine(DestroyProjectile());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(IgnoreTag))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class Projectile_Script : MonoBehaviour
{

    public Rigidbody rb;
    public float projectileSpeed, damage, delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * projectileSpeed);
        StartCoroutine(DestroyProjectile());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
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

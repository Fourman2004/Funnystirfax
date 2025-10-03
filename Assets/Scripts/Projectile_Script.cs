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

    // Update is called once per frame
    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

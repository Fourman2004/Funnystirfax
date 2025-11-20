using System.Collections;
using UnityEngine;

public class Projectile_Script : MonoBehaviour
{

    public Rigidbody rb;
    public float projectileSpeed, delay;
    public string IgnoreTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0,0,transform.forward.z) * projectileSpeed);
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

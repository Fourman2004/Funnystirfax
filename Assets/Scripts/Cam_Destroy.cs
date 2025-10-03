using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Cam_Destroy : MonoBehaviour
{

    [SerializeField]
    private Camera mainCam;

    Vector3 screenBounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        screenBounds = mainCam.WorldToViewportPoint(transform.position);
        if (screenBounds.x < 0 || screenBounds.x > 1)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed on the X");
        }
        else if (screenBounds.y > 1 || screenBounds.y < 0)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed on the Y");
        }             
    }
}

using UnityEngine;

public class ship_Shoot : MonoBehaviour
{
    GameObject target;
    bool doonce = false;
    Player_Controls Player_Controls;
    public GameObject projectile;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        Player_Controls = target.GetComponent<Player_Controls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Controls.attack.ReadValue<float>() == 1 && !doonce)
        {
            Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.localPosition.z + -10), Quaternion.identity);
            doonce = true;
        }
        else
        {
            doonce = false;
        }
    }
}

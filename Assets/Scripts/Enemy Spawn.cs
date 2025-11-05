using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    Quaternion Rotation;

    public Collider collison;
    public Gamemanager GM;
    public GameObject[] obstacles;
    // Start is called before the first frame update
    void Start()
    { }
 

    // Update is called once per frame
    void Update()
    {
        if(GM.m_currentState == Gamemanager.GameState.Playing)
        {
                spawnobstacles();
        }
    }

    public void spawnobstacles()
    {
        int obstacletype = Random.Range(0, 2);
        Debug.Log(obstacletype);
        GameObject Crap = obstacles[obstacletype];
        Crap.transform.position = this.RandspawnPosition(this.gameObject.transform.position, this.gameObject.transform.localScale);
        Instantiate(Crap, Crap.transform.position, Crap.transform.rotation);
    }
    Vector3 RandspawnPosition(Vector3 start, Vector3 scale)
    {
        return new(Random.Range(start.x - scale.x, start.x + scale.x), 
                    Random.Range(start.y - scale.y, start.y + scale.y), 
                    Random.Range(start.z - scale.z, start.z + scale.z));
    }
}

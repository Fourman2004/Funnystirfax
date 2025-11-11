using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    Quaternion Rotation;

    public Collider collison;
    public Gamemanager GM;
    public GameObject[] obstacles;
    [SerializeField]
    public int obstacleamount = 0, shipamount = 0;
    // Start is called before the first frame update
    void Start()
    { }
 

    // Update is called once per frame
    void Update()
    {
        if(GM.m_currentState == Gamemanager.GameState.Playing)
        {
                spawnobstacles(100, 5);
        }
    }

    public void spawnobstacles(int Astroidcap, int Shipcap)
    {
        int obstacletype = Random.Range(0, obstacles.Length);
        GameObject obstacle = obstacles[obstacletype];
        Debug.Log(obstacletype);
        if (obstacleamount != Astroidcap && obstacle.CompareTag(""))
        {
            obstacle.transform.position = this.RandspawnPosition(this.gameObject.transform.position, this.gameObject.transform.localScale);
            Instantiate(obstacle, obstacle.transform.position, obstacle.transform.rotation);
            obstacleamount++;
        }

    }
    Vector3 RandspawnPosition(Vector3 start, Vector3 scale)
    {
        return new(Random.Range(start.x - scale.x, start.x + scale.x), 
                    Random.Range(start.y - scale.y, start.y + scale.y), 
                    Random.Range(start.z - scale.z, start.z + scale.z));
    }
}

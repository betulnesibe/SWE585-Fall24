using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 2f;
    public float range = 5f;
    private Vector3 startPos;

/*  // to move the obstacle manually

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        transform.position = startPos + new Vector3(0, 0, Mathf.PingPong(Time.time * speed, range));
    }
*/
  /*  
    // to change the update time of the obstacle carving manually
    private float updateTime = 0f;

        void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        transform.position = startPos + new Vector3(0, 0, Mathf.PingPong(Time.time * speed, range));

        // cache updates to every 1 seconds
        if (Time.time > updateTime)
        {
            updateTime = Time.time + 1f;
            UpdateNavMeshObstacle();
        }
    }

    void UpdateNavMeshObstacle()
    {
        var navMeshObstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        if (navMeshObstacle != null)
        {
            navMeshObstacle.carveOnlyStationary = false; // Allow carving updates.
        }
    }
    */


     // to change carving frequency and time to stationary from unity settings
        void Start()
    {
        startPos = transform.position;

        var navMeshObstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        if (navMeshObstacle != null)
        {
            navMeshObstacle.carvingMoveThreshold = 0.1f; // minimum movement to trigger carving. default is 0.1f
            navMeshObstacle.carvingTimeToStationary = 1f; // time before considering stationary. default is 0.5f
        }
    }

    void Update()
    {
        transform.position = startPos + new Vector3(0, 0, Mathf.PingPong(Time.time * speed, range));
    }

}
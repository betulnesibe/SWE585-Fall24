/*// code where agents spawned at random points which gives incorrect experiment results.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public GameObject agentPrefab;
    public int agentCount = 10;
    public Transform ground;
    public Transform target;

    void Start()
    {
        for (int i = 0; i < agentCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-ground.localScale.x * 5, ground.localScale.x * 5),
                0.5f,
                Random.Range(-ground.localScale.z * 5, ground.localScale.z * 5)
            );

            GameObject newAgent = Instantiate(agentPrefab, randomPosition, Quaternion.identity);
            AgentController controller = newAgent.GetComponent<AgentController>();
            controller.target = target; // to assign the target dynamically
        }
    }
}*/


// code to spawn agents at fixed point on the floor.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public GameObject agentPrefab;
    public Transform ground;
    public Transform target;
    public int agentCount = 10; 
    private List<Vector3> spawnPoints;

    void Start()
    {
        spawnPoints = GenerateFixedPoints(agentCount);
        for (int i = 0; i < agentCount; i++)
        {
            Vector3 spawnPosition = spawnPoints[i];
            GameObject newAgent = Instantiate(agentPrefab, spawnPosition, Quaternion.identity);
            AgentController controller = newAgent.GetComponent<AgentController>();
            controller.target = target; 
        }
    }

    List<Vector3> GenerateFixedPoints(int count)
    {
        List<Vector3> points = new List<Vector3>();


        float leftX = -46.7f;
        float rightX = 45.2f;
        float topZ = 39.1f;
        float bottomZ = -47.4f;
        float y = 0f; 

        int rows = Mathf.CeilToInt(Mathf.Sqrt(count));
        int cols = rows; 

        float spacingX = Mathf.Abs(rightX - leftX) / cols;
        float spacingZ = Mathf.Abs(topZ - bottomZ) / rows;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (points.Count >= count) break;

                float x = leftX + col * spacingX + spacingX / 2;
                float z = bottomZ + row * spacingZ + spacingZ / 2;

                points.Add(new Vector3(x, y, z));
            }
        }

        return points;
    }
}

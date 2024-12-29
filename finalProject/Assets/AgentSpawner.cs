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
}
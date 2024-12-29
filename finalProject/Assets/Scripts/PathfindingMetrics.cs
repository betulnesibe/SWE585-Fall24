using UnityEngine;
using UnityEngine.AI;

public class PathfindingMetrics : MonoBehaviour
{
    private NavMeshAgent agent;
    private float pathStartTime;
    private int recalculations = 0;
    private Vector3 lastDestination;
    private Vector3 previousCorner;
    private bool pathStarted = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // to start pathfinding and log start time
        pathStartTime = Time.time;
        lastDestination = agent.destination;

        // to assign target destination
        Transform target = GameObject.Find("target").transform;
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }


    void Update()
    {
        // Measure Pathfinding Time
        if (!pathStarted && !agent.pathPending && agent.hasPath)
        {
            pathStarted = true;
            float pathCalculationTime = Time.time - pathStartTime;
            Debug.Log($"Pathfinding Time: {pathCalculationTime:F2} seconds");
        }

        // Count Path Recalculations due to dynamic obstacles
        if (!agent.pathPending && agent.hasPath && HasPathChanged())
        {
            recalculations++;
            Debug.Log($"Path Recalculation {recalculations}: Path recalculated due to dynamic changes.");
        }

        // Calculate Path Length
        if (!agent.pathPending && agent.hasPath && agent.remainingDistance < agent.stoppingDistance)
        {
            float pathLength = CalculatePathLength(agent.path);
            Debug.Log($"Final Path Length: {pathLength:F2} units");
            Debug.Log($"Total Path Recalculations: {recalculations}");

            // Disable the script after metrics are logged
            this.enabled = false;
        }
    }






    private bool HasPathChanged()
    {
        if (agent.path.corners.Length > 1)
        {
            // Check if the first corner of the path has changed significantly
            if (previousCorner != agent.path.corners[0])
            {
                previousCorner = agent.path.corners[0];
                return true;
            }
        }
        return false;
    }

    private float CalculatePathLength(NavMeshPath path)
    {
        float length = 0.0f;
        if (path.corners.Length < 2)
            return length;

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            length += Vector3.Distance(path.corners[i], path.corners[i + 1]);
        }
        return length;
    }
}
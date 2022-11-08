using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeList : MonoBehaviour
{
    public Transform GetWaypoint(int waypointIndex)   // All this does is grab the Transform gameobject according to the index (start at 0)
    {
        return transform.GetChild(waypointIndex);
    }

    public int GetNextWaypointIndex(int currentWaypointIndex)   // All this does is add 1 to the index or loop it if it reach the max child count
    {
        int nextWaypointIndex = currentWaypointIndex + 1;

        if (nextWaypointIndex == transform.childCount)  // Loop index
        {
            nextWaypointIndex = 0;
        }

        return nextWaypointIndex;
    }

    private void OnDrawGizmos()
    {
        for (int waypointIndex = 0; waypointIndex < transform.childCount; waypointIndex++)
        {
            var waypoint = GetWaypoint(waypointIndex);

            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(waypoint.position, 0.2f);

            int nextWaypointIndex = GetNextWaypointIndex(waypointIndex);
            var nextWaypoint = GetWaypoint(nextWaypointIndex);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(waypoint.position, nextWaypoint.position);
        }
    }
}
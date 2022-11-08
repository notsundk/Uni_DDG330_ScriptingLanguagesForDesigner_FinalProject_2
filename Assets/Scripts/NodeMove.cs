using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private NodeList _nodeList;
    [SerializeField] private float _speed;

    [Header("Current Waypoint")]
    [SerializeField] private int _waypointIndex;
    [SerializeField] private Transform _previousWaypoint;
    [SerializeField] private Transform _targetWaypoint;

    [Header("Elapsed Time")]
    [SerializeField] private float _timeToWaypoint;
    [SerializeField] private float _elapsedTime;

    void Start()
    {
        TargetNextWaypoint();   // Set the previous Transform to the first
    }

    void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;

        float elapsedPecentage = _elapsedTime / _timeToWaypoint;
        elapsedPecentage = Mathf.SmoothStep(0f, 1f, elapsedPecentage);  // Smooth at the limit of the elapsedPercentage

        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPecentage);      // Movement
        transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPecentage);   // Rotation

        if (elapsedPecentage >= 1)
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        // Setting waypoint index and getting the transform pf the previous and target waypoint

        _previousWaypoint = _nodeList.GetWaypoint(_waypointIndex);
        _waypointIndex = _nodeList.GetNextWaypointIndex(_waypointIndex);
        _targetWaypoint = _nodeList.GetWaypoint(_waypointIndex);
        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }
}

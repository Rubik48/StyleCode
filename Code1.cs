using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _placesContainer;

    private Transform[] _waypoints;
    private int _currentWaypointIndex;

    private void Start()
    {
        InitializeWaypoints();
    }

    private void Update()
    {
        MoveToCurrentWaypoint();
    }

    private void InitializeWaypoints()
    {
        _waypoints = new Transform[_placesContainer.childCount];
        
        for (int i = 0; i < _placesContainer.childCount; i++)
        {
            _waypoints[i] = _placesContainer.GetChild(i);
        }
    }

    private void MoveToCurrentWaypoint()
    {
        Transform targetWaypoint = _waypoints[_currentWaypointIndex];
        
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetWaypoint.position,
            _moveSpeed * Time.deltaTime
        );

        if (transform.position == targetWaypoint.position)
        {
            UpdateNextWaypoint();
        }
    }

    private void UpdateNextWaypoint()
    {
        _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        
        Vector3 nextPosition = _waypoints[_currentWaypointIndex].position;
        Vector3 direction = nextPosition - transform.position;
        
        transform.forward = direction;
    }
}
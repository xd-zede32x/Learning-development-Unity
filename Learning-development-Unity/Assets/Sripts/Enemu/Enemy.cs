using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _patrolRoute;
    [SerializeField] private List<Transform> _locations;

    private int _locationIndex = 0;
    private NavMeshAgent _agent;

    private int _lives = 20;
    public int EnemyLives
    {
        get { return _lives; }

        private set
        {
            _lives = value;

            if (_lives <= 0)
            {
                Destroy(transform.gameObject);
            }
        }
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player").transform;

        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.1f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    private void InitializePatrolRoute()
    {
        foreach (Transform item in _patrolRoute)
        {
            _locations.Add(item);
        }
    }

    private void MoveToNextPatrolLocation()
    {
        if (_locations.Count == 0)
        {
            return;
        }

        _agent.destination = _locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % _locations.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _agent.destination = _player.position;
        }
    }   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EnemyLives -= 3;
        }
    }
}
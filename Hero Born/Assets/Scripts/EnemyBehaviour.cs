using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform PatrolRoute;
    public List<Transform> Locations;
    private int _locationIndex = 0;
    // UnityEngine.AI gives access to Unity's Navigation classes
    private NavMeshAgent _agent;

    public Transform Player;

    private int _lives = 3;
    public int EnemyLives
    {
        get
        {
            return _lives;
        }

        // Only this class has access to the set functionality
        private set
        {
            _lives = value;

            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy defeated");
            }
        }
    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        InitialisePatrolRoute();

        MoveToNextPatrolLocation();

        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void InitialisePatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;

        _agent.destination = Locations[_locationIndex].position;

        _locationIndex = (_locationIndex + 1) % Locations.Count;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Unity adds the "(Clone)" suffix (no spaces) to any object created
        // using the Instantiate method
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Enemy hit");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _agent.destination = Player.position;
            Debug.Log("Player detected - Attack!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
}
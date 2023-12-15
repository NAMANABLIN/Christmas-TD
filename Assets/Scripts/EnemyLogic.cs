using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour
{
    private int _health = 100;
    private int _damage = 20;
    [SerializeField] private EnemyConfig _config;
    [SerializeField] private NavMeshAgent Agent;
    [SerializeField] private Transform _target;
    void Start()
    {
        Setup(1);
        Agent.SetDestination(_target.position);
    }

    public void Setup(int level)
    {
        var data = _config.GetEnemyData(level);
        _health = data.health;
        _damage = data.damage;
        Agent.speed = data.moveSpeed;
        Agent.angularSpeed = data.rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(_target.position);
    }

    void Attack()
    {
        
    }
    
}

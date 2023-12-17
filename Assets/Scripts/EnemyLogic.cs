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
    private GameManager _gameManager;

    public void Setup(int level, Transform target)
    {
        var data = _config.GetEnemyData(level);
        _health = data.health;
        _damage = data.damage;
        Agent.speed = data.moveSpeed;
        Agent.angularSpeed = data.rotationSpeed;
        _target = target;
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(_target.position);
    }

    void Attack()
    {
        
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
    }

    void Death()
    {
        
    }

    void CheckIsLife()
    {
        
    }
}

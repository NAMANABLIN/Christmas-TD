using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    [SerializeField] private float _healthFactor;
    [SerializeField] private float _damageFactor;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private int _maxLevel;

    [SerializeField] private TableLevel table;

    [Serializable]
    struct TableLevel
    {
        public EnemyData[] EnemyDatas;
    }

    void OnValidate()
    {
        var EnemyDatas = new EnemyData[_maxLevel];
        for (int i = 0; i < _maxLevel; i++)
        {
            EnemyDatas[i].health = (int)(_health + _health * _healthFactor * i);
            EnemyDatas[i].damage = (int)(_damage + _damage * _damageFactor * i);
            EnemyDatas[i].rotationSpeed = _rotationSpeed;
            EnemyDatas[i].moveSpeed = _moveSpeed;
        }

        table.EnemyDatas = EnemyDatas;
    }

    public EnemyData GetEnemyData(int levelWave)
    {
        var EnemyDatas = new EnemyData
        {
            health = (int)(_health + _health * _healthFactor * levelWave - 1),
            damage = (int)(_damage + _damage * _damageFactor * levelWave - 1),
            rotationSpeed = _rotationSpeed,
            moveSpeed = _moveSpeed
        };
        return EnemyDatas;
    }
}

[Serializable]
public struct EnemyData
{
    public int health;
    public int damage;
    public float moveSpeed;
    public float rotationSpeed;
}
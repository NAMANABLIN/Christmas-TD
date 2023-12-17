using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class RandomizeChristmasTree : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab; // Префаб объекта, который будет расставлен
    [SerializeField] private GameObject _treesParent; // Префаб объекта, который будет расставлен
    
    [SerializeField] private int numObjects = 50;
    [SerializeField] private Transform _center;
    [SerializeField] private float _spawnRadius = 10f;
    [SerializeField] private float _maxArea = 10f; 
    [SerializeField] private float _emptyArea = 20f; 
    [SerializeField] private int _numberOfSpawnAreas = 5;
    [SerializeField] private int _constantDensity = 20;
    private GameObject[] trees;


    public void Run()
    {
        GenerateObjectsInArea();

    }

    void GenerateObjectsInArea()
    {
        for (int j = 0; j < _numberOfSpawnAreas; j++)
        {
            int countOfTrees = numObjects * (j + 1 + j * _constantDensity);
            for (int i = 0; i < countOfTrees; i++)
            {
                float randomPI = Random.Range(0, Mathf.PI);
                float randomAreaDistance = Random.Range(0, _maxArea);
                Vector3 position = (_emptyArea + randomAreaDistance + _spawnRadius*(j+1)) *
                                   (Vector3.forward * Mathf.Sin(randomPI) + Mathf.Cos(randomPI) * Vector3.left);

                Instantiate(_objectPrefab, position, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f), _treesParent.transform);
            }
        }
    }
}
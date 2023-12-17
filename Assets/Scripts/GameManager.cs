using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.Serialization;

using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [FormerlySerializedAs("wave")] public int waveLevel = 1;
    private float _waveTime = 120f; // время на волну
    private bool _waveOrChill= false; // идёт волна или нет
    private float _chillTime = 1f; // время на отдых
    private float _currentTime;

    [SerializeField] private float _maxArea = 6;
    [SerializeField] private float _spawnDistance = 15;
    
    private float _intervalSpawn;
    private int _startValueOfEnemy = 1;             
    private float _enemyFactor = 0.1f;
    private Dictionary<int, EnemyLogic> _enemies = new Dictionary<int, EnemyLogic>();
    private int _snowmanID = 0;
    
    [SerializeField] private PlayerManager _player;
    [SerializeField] private GameObject _christmasTree;
    [SerializeField] private GameObject _mountains;
    
    [SerializeField] private TextMeshProUGUI _timerText; 
    [SerializeField] private TextMeshProUGUI _waveText; 
    [SerializeField] private EnemyLogic _snowman;
    [SerializeField] private RandomizeChristmasTree _randomizeTree;
    [SerializeField] private NavMeshSurface _navMeshSurface;


    void Start()
    {
        _currentTime = _chillTime;
        UpdateTimerText();
                                                 
        
        _player.gameObject.SetActive(false);
        _christmasTree.gameObject.SetActive(false);
        _mountains.gameObject.SetActive(false);
        
        _randomizeTree.Run();
        _navMeshSurface.BuildNavMesh();
        
        _player.gameObject.SetActive(true);
        _christmasTree.gameObject.SetActive(true);
        _mountains.gameObject.SetActive(true);

    }
    private void Update()
    {
        _currentTime -= Time.deltaTime;
        
        if (_currentTime < 0)
        {
            if (_waveOrChill)
            {
                _waveOrChill = false;
                _currentTime = _chillTime;
            }
            else
            {
                _waveOrChill = true;
                _currentTime = _waveTime;
                waveLevel++;
                // Spawn();
            }
        }
        if (_enemies.Count == 0 && _waveOrChill)
        {
            _waveOrChill = false;
            _currentTime = _chillTime;
        }
        UpdateTimerText();
    }
    
    void UpdateTimerText()
    {
        // Преобразуем время в формат минут:секунды и обновляем текст
        int minutes = Mathf.FloorToInt(_currentTime / 60);
        int seconds = Mathf.FloorToInt(_currentTime % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator StartSpawnProcess()
    {
        float time = _chillTime;
        while (time>0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        Spawn();
        waveLevel++;
    }
    void Spawn()
    {
        int count = (int)(_startValueOfEnemy + (waveLevel-1)*_startValueOfEnemy*_enemyFactor);
        for (int i = 0; i < count; i++) 
        {
            
            float randomPI = Random.Range(0, Mathf.PI);
            float randomAreaDistance = Random.Range(0, _maxArea);
            Vector3 position = (_spawnDistance + randomAreaDistance) *
                               (Vector3.forward * Mathf.Sin(randomPI) + Mathf.Cos(randomPI) * Vector3.left);
            var enemy = Instantiate(_snowman, position, Quaternion.identity);
            enemy.Setup(waveLevel, transform);
            _enemies.Add(_snowmanID, enemy);
            
            _snowmanID++;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * 0.01f, _spawnDistance);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * 0.01f, _spawnDistance+_maxArea);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private List<EnemyLogic> _enemies = new List<EnemyLogic>();
    
    [SerializeField] private PlayerManager _player;
    [SerializeField] private TextMeshProUGUI _timerText; 
    [SerializeField] private EnemyLogic _snowman;


    void Start()
    {
        _currentTime = _chillTime;
        StartCoroutine(StartSpawnProcess());
        UpdateTimerText();
    }
    private void Update()
    {
        // _currentTime -= Time.deltaTime;
        //
        // if (_currentTime < 0)
        // {
        //     if (_waveOrChill)
        //     {
        //         _waveOrChill = false;
        //         _currentTime = _chillTime;
        //     }
        //     else
        //     {
        //         _waveOrChill = true;
        //         _currentTime = _waveTime;
        //         waveLevel++;
        //     }
        // }
        if (_enemies.Count == 0)
        {
            StartCoroutine(StartSpawnProcess());
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
            _enemies.Add(enemy);
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

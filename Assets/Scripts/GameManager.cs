using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [FormerlySerializedAs("wave")] public int waveLevel = 1;
    private float _waveTime = 120f; // время на волну
    private bool _waveOrChill= false; // идёт волна или нет
    private float _chillTime = 10f; // время на отдых
    private float _currentTime;

    private float _intervalSpawn;
    private int _enemyOnWave;             
    
    [SerializeField] private PlayerManager _player;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private GameObject _spawnpoints;
    [SerializeField] private EnemyLogic _snowman;


    void Start()
    {
        _currentTime = _chillTime;
        UpdateTimerText();
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
            }
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

    void Spawn()
    {
        
    }

}

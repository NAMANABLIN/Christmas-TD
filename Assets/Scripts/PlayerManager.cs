using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 100;
    [SerializeField] private float speed = 2f;
    private float _startSpeed;
    private float _weapon;
    private float _scrollSpeed = 10.0f; // Скорость прокрутки колесика мыши
    private int _currentValue = 1; // Текущее значение
    
    [SerializeField] private Rigidbody _rb;

    private void Awake()
    {
        _startSpeed = speed;
    }

    void Update()
    {
        // Получаем значение прокрутки колесика мыши
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");

        // Изменяем текущее значение в соответствии с прокруткой
        _currentValue += Convert.ToInt16(scrollValue * _scrollSpeed);
        if (_currentValue < 1)
        {
            _currentValue = 3;
        }

        if (_currentValue > 3)
        {
            _currentValue = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log(3);
        }

        // Debug.Log("Current Value: " + _currentValue);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += speed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = _startSpeed;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0f, z);

        var worldDirection = _rb.transform.TransformDirection(move);
        _rb.velocity = worldDirection*speed*Time.fixedDeltaTime;
    }
}

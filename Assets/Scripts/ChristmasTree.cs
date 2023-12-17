using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChristmasTree : MonoBehaviour, ITakeDamagable
{
    public float _health = 500f;
    [SerializeField] private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = _health / 500;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log(_health);
    }
}

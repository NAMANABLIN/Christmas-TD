using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourierTarget : MonoBehaviour
{
    public ITakeDamagable _currentTarget;
    [SerializeField] public Animator _animator;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(1);
        if (other.gameObject.TryGetComponent(out ITakeDamagable target))
        {
            Debug.Log(2);
            _currentTarget = target;
            _animator.SetBool("isAttacked", true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetMouseButtonDown(-1))
        {
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        
    }
}

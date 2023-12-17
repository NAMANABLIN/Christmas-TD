using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyEvent : MonoBehaviour
{
    [SerializeField] public EnemyLogic enemyLogic;

    void OnAttack()
    {
        enemyLogic.Attack();
    }
}

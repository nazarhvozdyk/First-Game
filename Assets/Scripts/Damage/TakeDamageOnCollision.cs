using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен

public class TakeDamageOnCollision : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public bool dieOnAnyCollision;
    private void OnCollisionEnter(Collision other)
    {
        if (dieOnAnyCollision == true)
        {
            enemyHealth.TakeDamage(Mathf.Infinity);
            return;
        }
    }
}

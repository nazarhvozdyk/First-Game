using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// скрипт уже проверен
public class EnemyHealth : MonoBehaviour
{
    public int health = 1;
    public UnityEvent eventOnTakeDamage;
    public UnityEvent eventOnDie;
    public void TakeDamage(float damageValue)
    {
        health -= (int)damageValue;

        if (health <= 0)
        {
            Die();
        }

        eventOnTakeDamage.Invoke();
    }
    private void Die()
    {
        Destroy(gameObject);
        eventOnDie.Invoke();
    }
}

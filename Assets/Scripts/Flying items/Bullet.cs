using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен
public class Bullet : MonoBehaviour
{
    public GameObject effectPrefab;
    public float damageValue = 1f;
    private void Start()
    {
        Destroy(gameObject, 4f);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(damageValue);
        }
        Destroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponentInParent<EnemyHealth>();
        if (enemyHealth)
        {
            enemyHealth.TakeDamage(damageValue);
            Destroy();
        }
    }

    private void Destroy()
    {
        Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

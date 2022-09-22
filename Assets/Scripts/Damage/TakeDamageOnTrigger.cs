using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен

public class TakeDamageOnTrigger : MonoBehaviour
{
    public bool dieOnAnyCollision;
    public EnemyHealth enemyHealth;
    private void OnTriggerEnter(Collider other)
    {
        if (dieOnAnyCollision)
        {
            if (other.isTrigger == false)
            {
                enemyHealth.TakeDamage(Mathf.Infinity);
                return;
            }
        }
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                enemyHealth.TakeDamage(1);
            }

        }
    }
}

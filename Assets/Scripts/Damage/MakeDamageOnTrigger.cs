using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            PlayerHealth playerHealth;

            other.attachedRigidbody.TryGetComponent<PlayerHealth>(out playerHealth);
            if (playerHealth)
            {
                playerHealth.TakeDamage(_damage);
            }
        }
    }
}

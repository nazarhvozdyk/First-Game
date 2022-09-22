using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен

public class LootHeal : MonoBehaviour
{
    [SerializeField]
    private int _health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody && other.attachedRigidbody.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.AddHealth(_health);
            Destroy(gameObject);
        }
    }
}

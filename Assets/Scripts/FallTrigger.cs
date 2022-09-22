using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(int.MaxValue);
        }
    }
}

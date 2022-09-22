using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;
    [SerializeField]
    private float _punchForce = 300f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        PlayerHealth playerHealth = null;

        if (other.rigidbody)
        {
            other.rigidbody.TryGetComponent<PlayerHealth>(out playerHealth);

            if (playerHealth)
            {
                Vector3 firstContactNormal = other.contacts[0].normal;
                _rigidbody.AddForce(firstContactNormal * _punchForce);

                other.rigidbody.AddForce(FindDirectionOfPunch(firstContactNormal) * _punchForce);
                playerHealth.TakeDamage(_damage);
            }
        }
    }

    private Vector3 FindDirectionOfPunch(Vector3 pointToPunch)
    {
        Vector3 resoult = Vector3.zero;
        resoult.y = 0;

        if (pointToPunch.x > 0)
        {
            resoult.x = -1;
        }
        else if (pointToPunch.x < 0)
        {
            resoult.x = 1;
        }

        resoult += Vector3.up;
        return resoult;
    }
}

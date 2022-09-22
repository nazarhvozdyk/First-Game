using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// скрипт уже проверен

public class Hen : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Rigidbody _rigidbody;
    private Transform _playerTransform;
    public float timeToReachSpeed = 1f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    private void FixedUpdate()
    {
        if (timeToReachSpeed == 0)
        {
            timeToReachSpeed = 1f;
        }
        if (_playerTransform)
        {
            Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
            Vector3 force = _rigidbody.mass * (toPlayer * _speed - _rigidbody.velocity) / timeToReachSpeed;

            _rigidbody.AddForce(force);
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}

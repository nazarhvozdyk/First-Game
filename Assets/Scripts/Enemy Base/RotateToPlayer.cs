using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField]
    private float _speedOfRotation = 2f;
    private Transform _playerTransform;
    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }
    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        float rotateY = _playerTransform.position.x > transform.position.x ? 180f : 0f;

        Vector3 rotation = new Vector3(0, rotateY, 0);

        transform.rotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotation), Time.deltaTime * _speedOfRotation);
    }
}

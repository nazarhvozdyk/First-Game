using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен
public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private float _rotationSpeed = 2f;
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    private void Update()
    {
        Vector3 toPlayer = _playerTransform.position - transform.position;

        transform.position += transform.forward * _speed * Time.deltaTime;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}

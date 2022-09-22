using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен

public class Carrot : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField]
    private float _speed = 1f;
    public Collider carrotCollider;
    public Rigidbody Rigidbody;
    public Rotate rotate;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
        Rigidbody.isKinematic = true;
        rotate.rotateEveryTime = false;
    }
    public void ThrowObjectAtPlayer()
    {
        Rigidbody.isKinematic = false;
        rotate.rotateEveryTime = true;

        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Rigidbody.velocity = toPlayer * _speed;
    }
}

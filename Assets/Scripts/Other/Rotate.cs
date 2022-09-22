using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен

public class Rotate : MonoBehaviour
{
    public bool rotateEveryTime = true;
    [SerializeField]
    private Vector3 _rotationSpeed;
    private void Update()
    {
        if (rotateEveryTime)
        {
            transform.Rotate(_rotationSpeed * Time.deltaTime);
        }
    }
}

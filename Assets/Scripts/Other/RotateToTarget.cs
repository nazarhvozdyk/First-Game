using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен

public class RotateToTarget : MonoBehaviour
{
    public Transform targetTransform;

    private void Rotate()
    {
        Vector3 toTarget = targetTransform.position - transform.position;

        transform.rotation =  Quaternion.LookRotation(toTarget);
    }

    private void Update()
    {
        Rotate();
    }
}

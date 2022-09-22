using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен

public class RotateToTargetEuler : MonoBehaviour
{
    public Vector3 leftEuler;
    public Vector3 rightEuler;
    public float rotationSpeed;

    private Vector3 _targetEuler;

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler), Time.deltaTime * rotationSpeed);
    }
    public void RotateLeft()
    {
        _targetEuler = leftEuler;
    }

    public void RotateRight()
    {
        _targetEuler = rightEuler;
    }
}

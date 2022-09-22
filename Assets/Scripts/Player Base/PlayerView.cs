using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен
public class PlayerView : MonoBehaviour
{
    [SerializeField] 
    private float _viewAngle;
    [SerializeField] 
    private float _speedOfRotate;
    public Transform AimTransform;
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float rotateY = AimTransform.position.x > transform.position.x ? -_viewAngle : _viewAngle;

        Vector3 rotation = new Vector3(0, rotateY, 0);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotation), Time.deltaTime * _speedOfRotate);
    }
}
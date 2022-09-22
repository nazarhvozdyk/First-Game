using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен
public class Follow : MonoBehaviour
{
    public Transform target;
    public float LerpRate;

    private void Update()
    {
        FollowToTarget();
    }

    protected virtual void FollowToTarget()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * LerpRate);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен
public class Head : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.position = target.position;
    }
}

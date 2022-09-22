using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен

public class RayGizmo : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Gizmos.DrawRay(ray);
    }
}

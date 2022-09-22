using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен
public class Acorn : MonoBehaviour
{
    public Vector3 velocity;
    public float maxRotationSpeed;
    public Rigidbody Rigidbody;
    private void Start()
    {
        Rigidbody.AddRelativeForce(velocity, ForceMode.VelocityChange);
        Rigidbody.angularVelocity = new Vector3(
            Random.Range(-maxRotationSpeed, maxRotationSpeed),
            Random.Range(-maxRotationSpeed, maxRotationSpeed),
            Random.Range(-maxRotationSpeed, maxRotationSpeed)
            );
    }
}

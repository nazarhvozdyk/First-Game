using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен
public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Transform ColliderTransform;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool isGrounded;
    public float maxSpeed;

    private int _jumpFrameCounter;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || isGrounded == false)
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 10f);
        }
        else
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, Vector3.one, Time.deltaTime * 10f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        float speedMultiplier = 1f;
        float horAxis = Input.GetAxis("Horizontal");

        if (isGrounded == false)
        {
            speedMultiplier = 0.2f;

            if (Rigidbody.velocity.x > maxSpeed && horAxis > 0f)
            {
                speedMultiplier = 0f;
            }
            if (Rigidbody.velocity.x < -maxSpeed && horAxis < 0f)
            {
                speedMultiplier = 0f;
            }
        }

        Rigidbody.AddForce(horAxis * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        if (isGrounded)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.fixedDeltaTime * 15f);
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
        }

        _jumpFrameCounter += 1;
        if (_jumpFrameCounter == 2)
        {
            Rigidbody.freezeRotation = false;
            Rigidbody.AddRelativeTorque(0f, 0f, 10f, ForceMode.VelocityChange);
        }
    }

    public void Jump()
    {
        _jumpFrameCounter = 0;
        Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);

    }

    private void OnCollisionStay(Collision other)
    {
        float angle = Vector3.Angle(other.contacts[0].normal, Vector3.up);
        if (angle < 45f)
        {
            isGrounded = true;
            Rigidbody.freezeRotation = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }

}

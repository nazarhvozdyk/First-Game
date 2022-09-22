using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    private FixedJoint _fixedJoint;
    public Rigidbody Rigidbody;

    public Collider own_collider;
    public Collider player_collider;

    public RopeGun ropeGun;

    private void Start()
    {
        Physics.IgnoreCollision(own_collider, player_collider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();

            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }

            if (ropeGun)
            {
                ropeGun.CreateSprint();
            }
        }
    }

    public void StopConnect()
    {
        if (_fixedJoint)
            Destroy(_fixedJoint);
    }
}

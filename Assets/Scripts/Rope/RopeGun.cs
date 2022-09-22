using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Flying,
    Active
}

public class RopeGun : MonoBehaviour
{
    public float speed = 20f;
    public float spring = 100f;
    public float damper = 5f;
    public RopeState currentRopeState;
    public RopeRenderer ropeRenderer;

    [Space(5)]
    public Hook hook;
    public Transform spawn;
    [HideInInspector]
    public SpringJoint springJoint;
    public Transform ropeStart;

    public PlayerMove playerMove;

    private float _length;
    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shoot();
        }
        if (currentRopeState == RopeState.Flying)
        {
            float distance = Vector3.Distance(ropeStart.transform.position, hook.transform.position);

            if (distance > 20f)
            {
                hook.gameObject.SetActive(false);
                currentRopeState = RopeState.Disabled;
                ropeRenderer.Hide();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentRopeState == RopeState.Active && playerMove.isGrounded == false)
            {
                playerMove.Jump();
            }
            DestroySpring();
        }

        if (currentRopeState == RopeState.Flying || currentRopeState == RopeState.Active)
        {
            ropeRenderer.Draw(ropeStart.position, hook.transform.position, _length);
        }
    }

    private void Shoot()
    {
        _length = 1f;

        if (springJoint)
            Destroy(springJoint);

        hook.gameObject.SetActive(true);
        hook.StopConnect();

        hook.transform.position = spawn.position;
        hook.transform.rotation = spawn.rotation;

        hook.Rigidbody.velocity = spawn.forward * speed;

        currentRopeState = RopeState.Flying;
    }

    public void CreateSprint()
    {
        if (springJoint)
        {
            return;
        }

        springJoint = gameObject.AddComponent<SpringJoint>();

        springJoint.anchor = ropeStart.localPosition;
        _length = Vector3.Distance(ropeStart.position, hook.transform.position);

        springJoint.connectedBody = hook.Rigidbody;
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.connectedAnchor = Vector3.zero;

        springJoint.spring = spring;
        springJoint.damper = damper;
        springJoint.maxDistance = _length;

        currentRopeState = RopeState.Active;
    }

    public void DestroySpring()
    {
        if (springJoint)
        {
            Destroy(springJoint);
            currentRopeState = RopeState.Disabled;
            hook.gameObject.SetActive(false);
            ropeRenderer.Hide();
        }
    }
}

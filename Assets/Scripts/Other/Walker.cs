using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Скрипт уже проверен

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    public Transform leftTarget;
    public Transform rightTarget;

    public float speed;
    public float stopTime;
    public Direction currentDirection;

    public Transform rayStart;
    public UnityEvent eventOnLeftTarget;
    public UnityEvent eventOnRightTarget;

    private bool _isStopped;

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;
    }
    private void Update()
    {
        if (_isStopped)
        {
            return;
        }

        Vector3 offset = new Vector3(Time.deltaTime * speed, 0f, 0f);
        SetDirction();

        if (currentDirection == Direction.Left)
        {
            transform.position -= offset;
        }
        else
        {
            transform.position += offset;
        }

        RaycastHit hit;

        if (Physics.Raycast(rayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    private void SetDirction()
    {
        if (transform.position.x < leftTarget.position.x)
        {
            currentDirection = Direction.Right;
            _isStopped = true;
            Invoke(nameof(ContinueWalk), stopTime);
            eventOnLeftTarget.Invoke();
        }
        else if (transform.position.x > rightTarget.position.x)
        {
            currentDirection = Direction.Left;
            _isStopped = true;
            Invoke(nameof(ContinueWalk), stopTime);
            eventOnRightTarget.Invoke();
        }
    }
    private void ContinueWalk()
    {
        _isStopped = false;
    }
}

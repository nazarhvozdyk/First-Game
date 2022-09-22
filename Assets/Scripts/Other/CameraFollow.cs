using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Follow
{
    public Vector3 cameraStartOffset = new Vector3(0, 2f, -10f);

    protected override void FollowToTarget()
    {
        if (target)
        {
            transform.position = Vector3.Lerp(
           transform.position,
           target.position + cameraStartOffset,
           Time.deltaTime * LerpRate
           );
        }
    }
}

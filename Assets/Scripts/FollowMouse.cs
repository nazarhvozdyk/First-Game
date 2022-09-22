using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // делаем прицел на UI
    private void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }
}

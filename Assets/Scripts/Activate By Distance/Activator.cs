using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [HideInInspector] public List<ActivateByDistance> objectsToActivate = new List<ActivateByDistance>();
    public Transform playerTransform;

    private void Update()
    {
        if (playerTransform)
        {
            for (int i = 0; i < objectsToActivate.Count; i++)
            {
                objectsToActivate[i].CheckDistance(playerTransform.position);
            }
        }
    }
}

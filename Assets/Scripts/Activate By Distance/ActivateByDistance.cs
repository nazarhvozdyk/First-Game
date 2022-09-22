using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ActivateByDistance : MonoBehaviour
{
    public float DistanceToActivate = 20f;
    private bool _isActive;
    private Activator _activator;

    private void Start()
    {
        _isActive = gameObject.activeSelf;

        _activator = FindObjectOfType<Activator>();

        _activator.objectsToActivate.Add(this);
    }
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (_isActive)
        {
            if (distance > DistanceToActivate + 2f)
            {
                DeActivate();
            }
        }
        else
        {
            if (distance < DistanceToActivate)
            {
                Activate();
            }
        }
    }

    public virtual void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    public virtual void DeActivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _activator.objectsToActivate.Remove(this);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
    }
#endif
}

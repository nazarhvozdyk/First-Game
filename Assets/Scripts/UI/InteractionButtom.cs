using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Скрипт уже проверен
public class InteractionButtom : MonoBehaviour
{
    public UpgrateTable upgrateTable;
    public CameraManager cameraManager;
    public Vector3 buttonPositionOffset;
    public UnityEvent EventOnInteract;

    private void Start()
    {
        transform.position = upgrateTable.transform.position + buttonPositionOffset;
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && gameObject.activeSelf)
        {
            EventOnInteract.Invoke();
            gameObject.SetActive(false);
        }
        transform.position = upgrateTable.transform.position + buttonPositionOffset;
    }
}

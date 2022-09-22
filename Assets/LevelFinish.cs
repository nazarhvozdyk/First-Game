using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public GameObject finishUI;
    public Menu menu;
    // UI appear animator
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.transform.position = transform.position;
            other.attachedRigidbody.velocity = Vector3.zero;

            menu.DisableComponents();
            menu.showMenu = false;
            finishUI.SetActive(true);

            animator.SetTrigger("Appear");
            Cursor.visible = true;
        }
    }
}

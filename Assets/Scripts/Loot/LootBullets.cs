using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    public int gunIndex;
    public int numberOfBullets;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody && other.attachedRigidbody.TryGetComponent(out PlayerArmory playerArmory))
        {
            for (int i = 0; i < playerArmory.playerInventory.Count; i++)
            {
                if (gunIndex == playerArmory.playerInventory[i].gunIndex)
                {
                    playerArmory.playerInventory[i].AddBullets(numberOfBullets);
                    Destroy(gameObject);
                }
            }
        }
    }
}

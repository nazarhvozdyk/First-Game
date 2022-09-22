using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен

public class PrefabCreator : MonoBehaviour
{
    public Transform spawnTransform;
    public GameObject prefab;
    public bool parentToSpawn = false;
    private GameObject newPrefab;
    public void Create()
    {
        newPrefab = null;

        if (parentToSpawn)
        {
            newPrefab = Instantiate(prefab, spawnTransform.position, spawnTransform.rotation, spawnTransform);
        }
        else
        {
            newPrefab = Instantiate(prefab, spawnTransform.position, spawnTransform.rotation);
        }
    }

    public void ThrowAtPlayer()
    {
        if (newPrefab == null)
        {
            return;
        }
        else
        {
            newPrefab.transform.parent = null;
            newPrefab.SendMessage("ThrowObjectAtPlayer");
        }
    }
}

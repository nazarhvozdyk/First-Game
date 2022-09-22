using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен
public class BatchPrefabCreator : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] spawnPoints;
    [ContextMenu("Create")]
    public void Create()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(prefab, spawnPoints[i].position, spawnPoints[i].rotation);
        }

    }
}

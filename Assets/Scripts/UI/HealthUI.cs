using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен
public class HealthUI : MonoBehaviour
{
    public GameObject healthIconPrefab;
    private List<GameObject> _healthIcons = new List<GameObject>();
    public void Setup(int health)
    {
        for (int i = 0; i < health; i++)
        {
            GameObject newIcon = Instantiate(healthIconPrefab, transform);
            _healthIcons.Add(newIcon);
        }
    }

    public void DisplayIcons(int health)
    {
        for (int i = 0; i < _healthIcons.Count; i++)
        {
            _healthIcons[i].SetActive(i < health);
        }
    }
}

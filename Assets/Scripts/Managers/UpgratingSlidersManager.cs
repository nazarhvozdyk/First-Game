using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgratingSlidersManager : MonoBehaviour
{
    public UpgrateManager upgrateManager;
    public UpgratingSlider[] allSliders;

    public void SetSliders()
    {
        for (int i = 0; i < allSliders.Length; i++)
        {
            allSliders[i].SetMinAndMaxValues();
            allSliders[i].SetSlider();
        }
    }

    public void ResetSliders()
    {
        for (int i = 0; i < allSliders.Length; i++)
        {
            allSliders[i].ResetSlider();
        }
    }

    public void UpdateSliders()
    {
        for (int i = 0; i < allSliders.Length; i++)
        {
            allSliders[i].UpdateSlider();
        }
    }
}

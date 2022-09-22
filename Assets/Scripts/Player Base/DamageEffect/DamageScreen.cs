using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// скрипт уже проверен
public class DamageScreen : MonoBehaviour
{
    public Image damageImage;

    public void StartEfect()
    {
        StartCoroutine(ShowEffect());
    }
    private IEnumerator ShowEffect()
    {
        damageImage.enabled = true;

        for (float t = 1; t > 0f; t -= Time.deltaTime)
        {
            damageImage.color = new Color(1, 0, 0, t);
            yield return null;
        }

        damageImage.enabled = false;
    }
}

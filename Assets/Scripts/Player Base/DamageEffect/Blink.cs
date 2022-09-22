using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен
public class Blink : MonoBehaviour
{
    public Renderer[] Renderer;
    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    private IEnumerator ShowEffect()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            for (int i = 0; i < Renderer.Length; i++)
            {
                for (int j = 0; j < Renderer[i].materials.Length; j++)
                {
                    Renderer[i].materials[j].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30f) * 0.5f + 0.5f, 0, 0, 0));
                }
            }

            yield return null;
        }
    }
}

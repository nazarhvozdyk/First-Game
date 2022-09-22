using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int segments = 10;

    public void Draw(Vector3 a, Vector3 b, float length)
    {
        lineRenderer.enabled = true;

        float interpolant = Vector3.Distance(a, b) / length;
        float offset = Mathf.Lerp(length / 2f, 0f, interpolant);

        Vector3 aDown = a + Vector3.down * offset;
        Vector3 bDown = b + Vector3.down * offset;

        lineRenderer.positionCount = segments + 1;

        for (int i = 0; i < segments + 1; i++)
        {
            lineRenderer.SetPosition(i, Bezier.GetPoint(a, aDown, bDown, b, (float)i / length));
        }
    }

    public void Hide()
    {
        lineRenderer.enabled = false;
    }
}

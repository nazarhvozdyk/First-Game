using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрисп проверен
public class TimeManager : MonoBehaviour
{
    public float timeScale = 0.2f;
    private float _startFixedDeltaTime;
    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetTime(timeScale);
        }
        if (Input.GetMouseButtonUp(1))
        {
            SetTime(1);
        }
    }

    private void SetTime(float time)
    {
        Time.timeScale = time;
        Time.fixedDeltaTime = _startFixedDeltaTime * timeScale;
    }
    private void OnDestroy()
    {
        SetTime(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт уже проверен

public class SetTringerEveryNSeconds : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    private float _period = 7f;
    private float _timer;
    public string triggerName = "Attack";

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _period)
        {
            _timer = 0f;
            animator.SetTrigger(triggerName);
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

// скрипт уже проверен, но надо зделать лучше, я помню

public class EventsArray : MonoBehaviour
{
    public UnityEvent[] Events;

    private void StartEvent(int eventIndex)
    {
        Events[eventIndex].Invoke();
    }
}

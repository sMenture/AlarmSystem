using System;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public event Action IntrusionDetected;
    public event Action IntrusionEnded;

    private void OnTriggerEnter(Collider other)
    {
        if (IsThief(other) == false)
            return;

        IntrusionDetected?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsThief(other) == false)
            return;

        IntrusionEnded?.Invoke();
    }

    private bool IsThief(Collider other)
    {
        return other.TryGetComponent(out Thief thief);
    }
}

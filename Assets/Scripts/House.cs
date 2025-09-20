using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AreaTrigger _inAndOut;
    [SerializeField] private AlarmSystem _alarmSystem;

    private void OnEnable()
    {
        _inAndOut.IntrusionDetected += IntrusionDetected;
        _inAndOut.IntrusionEnded += IntrusionEnded;
    }

    private void OnDisable()
    {
        _inAndOut.IntrusionDetected -= IntrusionDetected;
        _inAndOut.IntrusionEnded -= IntrusionEnded;
    }

    private void IntrusionDetected()
    {
        _alarmSystem.StartFade(true);
    }

    private void IntrusionEnded()
    {
        _alarmSystem.StartFade(false);
    }
}

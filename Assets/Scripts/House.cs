using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AreaTrigger _inAndOut;
    [SerializeField] private AlarmSystem _alarmSystem;

    private void OnEnable()
    {
        _inAndOut.IntrusionDetected += () => _alarmSystem.StartFade(true);
        _inAndOut.IntrusionEnded += () => _alarmSystem.StartFade(false);
    }

    private void OnDisable()
    {
        _inAndOut.IntrusionDetected -= () => _alarmSystem.StartFade(true);
        _inAndOut.IntrusionEnded -= () => _alarmSystem.StartFade(false);
    }
}

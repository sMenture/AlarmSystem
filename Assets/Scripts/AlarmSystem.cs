using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _fadeSpeed = 0.5f;

    private AudioSource _audioSource;
    private bool _isEnabled = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        _audioSource.loop = true;
    }

    private void Update()
    {
        const float MinimumValue = 0.01f;

        float targetVolume = _isEnabled ? 1 : 0f;
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _fadeSpeed * Time.deltaTime);

        if (_isEnabled && _audioSource.isPlaying == false && _audioSource.volume > MinimumValue)
        {
            _audioSource.Play();
        }
        else if (!_isEnabled && _audioSource.isPlaying && _audioSource.volume < MinimumValue)
        {
            _audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsThief(other))
        {
            _isEnabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsThief(other))
        {
            _isEnabled = false;
        }
    }

    private bool IsThief(Collider other)
    {
        return other.TryGetComponent(out Thief thief);
    }
}

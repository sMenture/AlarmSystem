using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    private const float MinimumValue = 0.01f;

    [SerializeField] private float _fadeSpeed = 0.5f;

    private AudioSource _audioSource;
    private Coroutine _fadeCoroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        _audioSource.loop = true;
    }

    public void StartFade(bool isEnable)
    {
        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(FadeVolume(isEnable ? 1 : 0));
    }

    private IEnumerator FadeVolume(float targetVolume)
    {
        if (targetVolume > MinimumValue && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        while (!Mathf.Approximately(_audioSource.volume, targetVolume))
        {
            _audioSource.volume = Mathf.MoveTowards(
                _audioSource.volume,
                targetVolume,
                _fadeSpeed * Time.deltaTime
            );
            yield return null;
        }

        if (targetVolume < MinimumValue && _audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }
}
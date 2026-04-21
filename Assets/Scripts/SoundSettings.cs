using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    private const float LogToLinearScale = 20f;

    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private MusicSettingsType _musicSettingsType;
    [SerializeField] private Slider _slider;

    private string _nameMusicSettings;

    private void Awake()
    {
        _nameMusicSettings = _musicSettingsType.ToString();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float level)
    {
        _audioMixer.audioMixer.SetFloat(_nameMusicSettings, Mathf.Log10(level) * LogToLinearScale);
    }
}
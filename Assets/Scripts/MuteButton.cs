using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private Toggle _muteButton;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private MusicSettingsType _musicSettingsType;

    private float _minVolume = -80f;
    private float _currentVolume;
    private string _nameMusicSettings;

    private void Awake()
    {
        _nameMusicSettings = _musicSettingsType.ToString();
    }

    private void OnEnable()
    {
        _muteButton.onValueChanged.AddListener(ToggleSound);
    }

    private void OnDisable()
    {
        _muteButton.onValueChanged.RemoveListener(ToggleSound);
    }

    private void ToggleSound(bool isDisabled)
    {
        if (isDisabled)
        {
            _audioMixerGroup.audioMixer.SetFloat(_nameMusicSettings, _minVolume);
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat(_nameMusicSettings, _currentVolume);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumePanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterVolume;
    [SerializeField] private AudioMixerGroup _musicVolume;
    [SerializeField] private AudioMixerGroup _effectsVolume;

    [SerializeField] private MasterSoundChanger _masterSoundChanger;

    private readonly string _masterVolumeName = "MasterVolume";
    private readonly string _musicVolumeName = "MusicVolume";
    private readonly string _effectsVolumeName = "EffectsVolume";

    private readonly float _minVolume = -50;
    private readonly float _maxVolume = 0;

    public void ChangeMasterVolume(float volume)
    {
        ChangeVolume(volume, _masterVolume, _masterVolumeName);
    }
    
    public void ChangeMusicVolume(float volume)
    {
        ChangeVolume(volume, _musicVolume, _musicVolumeName);
    }
    
    public void ChangeEffectsVolume(float volume)
    {
        ChangeVolume(volume, _effectsVolume, _effectsVolumeName);
    }

    private void ChangeVolume(float volume, AudioMixerGroup volumeMixer, string mixerName)
    {
        if(_masterSoundChanger.IsSoundsEnable)
            volumeMixer.audioMixer.SetFloat(mixerName, Mathf.Lerp(_minVolume, _maxVolume, volume));
    }
}

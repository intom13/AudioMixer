using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class MasterSoundChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterVolume;

    private readonly float _minVolume = -80;
    private readonly float _maxVolume = 0;

    private readonly string _masterVolumeName = "MasterVolume";

    private bool _isSoundsEnable;

    public bool IsSoundsEnable => _isSoundsEnable;

    public void Click()
    {
        if (_isSoundsEnable)
            SwitchSoundsOff();
        else
            SwitchSoundsOn();
    }

    private void SwitchSoundsOn()
    {
        _isSoundsEnable = true;
        _masterVolume.audioMixer.SetFloat(_masterVolumeName, _maxVolume);
    }

    private void SwitchSoundsOff()
    {
        _isSoundsEnable = false;
        _masterVolume.audioMixer.SetFloat(_masterVolumeName, _minVolume);
    }
}

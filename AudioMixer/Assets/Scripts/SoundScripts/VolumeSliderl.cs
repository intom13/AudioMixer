using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private MasterSoundChanger _masterSoundChanger;
    [SerializeField] private AudioMixerGroup _volumeMixer;
    [SerializeField] private string _mixerParameterName;

    private readonly float _multiplieCoefficent = 20f;

    public void ChangeVolume(float sliderValue)
    {
        if(_masterSoundChanger.IsSoundsEnable)
            _volumeMixer.audioMixer.SetFloat(_mixerParameterName, Mathf.Log10(sliderValue) * _multiplieCoefficent);
    }
}

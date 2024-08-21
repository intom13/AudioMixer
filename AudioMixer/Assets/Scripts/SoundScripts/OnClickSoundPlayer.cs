using UnityEngine;

public class OnClickSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    public void PlaySound()
    {
        _audioSource.Play();
    }
}

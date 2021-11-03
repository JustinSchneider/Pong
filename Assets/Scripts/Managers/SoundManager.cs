using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip bgMusic;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
        audioSource.PlayOneShot(bgMusic);
        audioSource.PlayScheduled(AudioSettings.dspTime + bgMusic.length);
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void SetPauseStatus(bool status)
    {
        audioSource.volume = status ? 0.25f : 0.5f;
        audioSource.pitch = status ? 0.5f : 1f;
    }
}

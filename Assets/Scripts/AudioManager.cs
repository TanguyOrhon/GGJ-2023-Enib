using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;

    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }
}

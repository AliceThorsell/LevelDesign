using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public Collider player;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private bool hasPlayed = false;
    private void OnTriggerEnter(Collider player)
    {
        if (hasPlayed) return;

        hasPlayed = true; 

        audioSource.clip = audioClip;
        audioSource.Play();
    }
}

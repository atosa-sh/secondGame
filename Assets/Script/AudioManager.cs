using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource source;
 

    public void PlayAudio()
    {
        source.Play();
    }




}

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip jumpSound;
    public AudioClip attackSound;
    public AudioClip coinSound;
    public AudioClip damageSound;

    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(backgroundMusic);
    }

    // 🎵 MUSIC
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // 🔊 SFX
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        sfxSource.PlayOneShot(clip);
    }

    // 🎮 EASY FUNCTIONS
    public void PlayJump() => PlaySFX(jumpSound);
    public void PlayAttack() => PlaySFX(attackSound);
    public void PlayCoin() => PlaySFX(coinSound);
    public void PlayDamage() => PlaySFX(damageSound);
}
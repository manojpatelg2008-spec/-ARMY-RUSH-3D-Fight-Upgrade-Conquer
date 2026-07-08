using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip gunSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;
    public AudioClip winSound;
    public AudioClip gameOverSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayGun()
    {
        PlaySFX(gunSound);
    }

    public void PlayExplosion()
    {
        PlaySFX(explosionSound);
    }

    public void PlayCoin()
    {
        PlaySFX(coinSound);
    }

    public void PlayWin()
    {
        PlaySFX(winSound);
    }

    public void PlayGameOver()
    {
        PlaySFX(gameOverSound);
    }
}

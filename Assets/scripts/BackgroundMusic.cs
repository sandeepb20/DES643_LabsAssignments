using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;

    public AudioClip BackgroundMusicClip;


    private AudioSource audioSource;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BackgroundMusicClip;
        audioSource.loop = true;
    }

    public void PlayBackgroundMusic()
    {
        audioSource.Play();

    }

    public void StopBackgroundMusic()
    {
        audioSource.Stop();
    }
    public void PauseBackgroundMusic()
    {
        audioSource.Pause();
    }
    public void ResumeBackgroundMusic()
    {
        audioSource.UnPause();
    }
}

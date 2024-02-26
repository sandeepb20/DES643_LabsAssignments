using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public Flappingo flappingo;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;
    private bool isPaused = false;

    public AudioClip pauseGameSound;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;

            // Handle pausing and resuming the game
            if (isPaused)
            {
                Time.timeScale = 0f;
                FindObjectOfType<BackgroundMusic>().PauseBackgroundMusic();
                FindObjectOfType<Sound>().PlaySound(pauseGameSound);

            }
            else
            {
                Time.timeScale = 1f;
                FindObjectOfType<BackgroundMusic>().ResumeBackgroundMusic();

            }
        }
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        flappingo.enabled = true;

        Pipe[] pipe = FindObjectsOfType<Pipe>();

        for (int i = 0; i < pipe.Length; i++)
        {
            Destroy(pipe[i].gameObject);
        }
        FindObjectOfType<BackgroundMusic>().PlayBackgroundMusic();


    }
    public void Pause()
    {
        Time.timeScale = 0f;
        flappingo.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
        FindObjectOfType<BackgroundMusic>().StopBackgroundMusic();

    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}

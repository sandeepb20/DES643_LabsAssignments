using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public Flappingo flappingo;
    public TextMeshProUGUI scoreText;
    public Text DevelopedByText;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject gameOver;
    public GameObject goldMedal;
    public GameObject silverMedal;
    public GameObject bronzeMedal;
    private int score;
    private bool isPaused = false;

    public AudioClip pauseGameSound;

    private void ShowMedal(int v)
    {
        goldMedal.SetActive(false);
        silverMedal.SetActive(false);
        bronzeMedal.SetActive(false);
        if (v == 1) goldMedal.SetActive(true);
        if (v == 2) silverMedal.SetActive(true);
        if (v == 3) bronzeMedal.SetActive(true);
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;
        pauseButton.SetActive(false);
        DevelopedByText.enabled = false;
        ShowMedal(0);
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
                pauseButton.SetActive(true);

            }
            else
            {
                Time.timeScale = 1f;
                FindObjectOfType<BackgroundMusic>().ResumeBackgroundMusic();
                pauseButton.SetActive(false);

            }
        }
    }
    public void Play()
    {
        score = 0;
        scoreText.text = "Your Score: " + score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        goldMedal.SetActive(false);
        silverMedal.SetActive(false);
        bronzeMedal.SetActive(false);
        Time.timeScale = 1f;
        flappingo.enabled = true;

        Pipe[] pipe = FindObjectsOfType<Pipe>();
        ShowMedal(0);
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
        DevelopedByText.enabled = true;
        Pause();
        FindObjectOfType<BackgroundMusic>().StopBackgroundMusic();
        // Show medals
        if (score > 0 && score <= 5) ShowMedal(3);
        if (score > 5 && score <= 10) ShowMedal(2);
        if (score > 10) ShowMedal(1);

    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Your Score: " + score.ToString();
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // Make sure this is included if you use TextMeshPro

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText; 
    public GameObject GameOverScreen;
    public AudioClip gameOverSound; 
    private AudioSource audioSource;
    public BackgroundMusicManager backgroundMusic;
    public bool isGameOver = false;
    public TextMeshProUGUI currentScoreGameOverText; 
    public TextMeshProUGUI highScoreGameOverText;    
    public GameObject startGameText; 
    public bool gameHasStarted = false; 
    public TextMeshProUGUI startScreenHighScoreText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false; 
            audioSource.spatialBlend = 0;    
        }

        if (backgroundMusic == null)
        {
            backgroundMusic = FindFirstObjectByType<BackgroundMusicManager>();
        }
        
        isGameOver = false;
        gameHasStarted = false; 
        startGameText.SetActive(true); 

        // Display high score on the start screen
        int highScoreAtStart = PlayerPrefs.GetInt("HighScore", 0);
        startScreenHighScoreText.text = "Highest: " + highScoreAtStart.ToString();
        startScreenHighScoreText.gameObject.SetActive(true); 
        
        Time.timeScale = 0; 
    }

    void Update()
    {
        if (!gameHasStarted && !isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartGame();
            }
        }
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        if (gameHasStarted && !isGameOver)
        {
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
    }

    public void StartGame()
    {
        gameHasStarted = true;
        startGameText.SetActive(false); 
        Time.timeScale = 1; 
    }

    public void RestartGame()
    {

        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }

        isGameOver = true;
        gameHasStarted = false; 
        Time.timeScale = 0; 
        GameOverScreen.SetActive(true);

        if (audioSource != null && gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
        
        if (backgroundMusic != null)
        {
            Destroy(backgroundMusic.gameObject);
        }

        // Handle High Score
        int highScore = PlayerPrefs.GetInt("HighScore", 0); 
        currentScoreGameOverText.text = "Score: " + playerScore.ToString(); 

        if (playerScore > highScore) 
        {
            highScore = playerScore; 
            PlayerPrefs.SetInt("HighScore", highScore); 
            PlayerPrefs.Save(); 
        }
        highScoreGameOverText.text = "High Score: " + highScore.ToString(); 
    }
}
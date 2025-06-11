using System;
using Unity.VisualScripting; 
using UnityEngine; 
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject GameOverScreen;
    public AudioClip gameOverSound; 
    private AudioSource audioSource;
    public BackgroundMusicManager backgroundMusic;

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
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        GameOverScreen.SetActive(true);

        if (audioSource)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
        
        if (backgroundMusic != null)
        {
            Destroy(backgroundMusic.gameObject);
        }
    }
}

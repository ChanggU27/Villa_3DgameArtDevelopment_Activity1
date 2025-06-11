using Unity.VisualScripting;
using UnityEngine;

public class TopExcessScript : MonoBehaviour
{
    public LogicScript logic;
    public AudioClip scoreSound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.gameObject.layer == 3)
        {
            logic.AddScore(4);
            audioSource.PlayOneShot(scoreSound);
        }

    }
}

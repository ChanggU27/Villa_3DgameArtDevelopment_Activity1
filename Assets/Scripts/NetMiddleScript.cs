using Unity.VisualScripting;
using UnityEngine;

public class NetMiddleScript : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.gameObject.layer == 3)
        {
            logic.AddScore(1);
            audioSource.PlayOneShot(scoreSound);
        }

    }
}

using Unity.VisualScripting;
using UnityEngine;

public class TopExcessScript : MonoBehaviour
{
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.gameObject.layer == 3)
        {
            logic.AddScore(4);
        }

    }
}

using System.Threading;
using UnityEngine;

public class NetSpawnScript : MonoBehaviour
{
    public GameObject Net;
    public float spawnRate = 1;
    private float timer = 0;
    public float heightOffset = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnNet();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnNet();
            timer = 0;
        }

    }
    void spawnNet()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(Net, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}

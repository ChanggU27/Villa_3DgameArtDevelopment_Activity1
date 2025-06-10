using UnityEngine;

public class NetMoveScript : MonoBehaviour
{
    public int moveSpeed = 5;
    public float deadZone = -40;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + moveSpeed * Time.deltaTime * Vector3.left;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Net Deleted");
            Destroy(gameObject);
        }
    }
}

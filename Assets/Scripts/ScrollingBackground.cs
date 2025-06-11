using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f; 
    public float backgroundWidth = 0f; 
    public GameObject otherBackground;
    public float overlapEpsilon = 0.001f;
    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        if (backgroundWidth == 0f)
        {
            if (mySpriteRenderer != null)
            {
                backgroundWidth = mySpriteRenderer.bounds.size.x;
            }
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x < -backgroundWidth)
        {
            if (otherBackground != null)
            {
                transform.position = new Vector3(otherBackground.transform.position.x + backgroundWidth - overlapEpsilon, transform.position.y, transform.position.z);
            }
        }
    }
}

using UnityEngine;

public class CookieTranslation : MonoBehaviour
{
    private bool isMoving = false;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (isMoving)
        {
            rb.velocity = new Vector2(1f, 0f);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = !isMoving;
        }
    }
}
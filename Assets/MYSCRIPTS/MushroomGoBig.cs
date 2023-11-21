using UnityEngine;

public class MushroomGoBig : MonoBehaviour
{
    private int touchCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float scalingFactor = 1.2f * Mathf.Pow(1.2f, touchCount);
            transform.localScale *= scalingFactor;
            
            touchCount++;
        }
    }
}
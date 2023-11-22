using UnityEngine;

public class MushroomGoBig : MonoBehaviour
{
    private int touchCount = 0;
    private Rigidbody2D rb;
    private MouseClickPlayer mouseClickPlayer;
    public GameObject MushroomPrefab;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.Find("Player");
        mouseClickPlayer = playerObject.GetComponent<MouseClickPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float scalingFactor = 1.2f * Mathf.Pow(1.2f, touchCount);
            transform.localScale *= scalingFactor;
            if (mouseClickPlayer != null)
            {
                mouseClickPlayer.SpawnPrefab(MushroomPrefab);
            }
            touchCount++;
        }
    }
    public void ScaleMushroom()
    {
        float scalingFactor = 1.2f * Mathf.Pow(1.2f, touchCount);
        transform.localScale *= scalingFactor;
        touchCount++;
    }
}
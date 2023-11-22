using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummieSpins : MonoBehaviour
{
    public float rotationSpeed = 200f;
    private bool rotateClockwise = true;
    private Rigidbody2D rb;
    private MouseClickPlayer mouseClickPlayer;
    public GameObject GummiePrefab;

    private void Start()
    {
        RotateObject();
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.Find("Player");
        mouseClickPlayer = playerObject.GetComponent<MouseClickPlayer>();
    }

    private void Update()
    {
        RotateObject();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rotateClockwise = !rotateClockwise;
            if (mouseClickPlayer != null)
            {
                mouseClickPlayer.SpawnPrefab(GummiePrefab);
            }
        }
    }

    private void RotateObject()
    {
        float rotationDirection = rotateClockwise ? 1f : -1f;
        transform.Rotate(Vector3.forward * rotationDirection * rotationSpeed * Time.deltaTime);
    }
    public void ToggleRotation()
    {
        rotateClockwise = !rotateClockwise;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutRotation : MonoBehaviour
{
    private bool isRotating = false;
    [SerializeField] private float RotationSpeed = -100f;
    private Rigidbody2D rb;
    private MouseClickPlayer mouseClickPlayer;
    public GameObject DonutPrefab;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.Find("Player");
        mouseClickPlayer = playerObject.GetComponent<MouseClickPlayer>();
    }
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * RotationSpeed);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isRotating = !isRotating;
            if (mouseClickPlayer != null)
            {
                mouseClickPlayer.SpawnPrefab(DonutPrefab);
            }
        }
    }
    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}

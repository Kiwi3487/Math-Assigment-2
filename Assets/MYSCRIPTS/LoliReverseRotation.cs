using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoliReverseRotation : MonoBehaviour
{
    private bool isRotating = false;
    private Rigidbody2D rb;
    private MouseClickPlayer mouseClickPlayer;
    public GameObject LoliPrefab;
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.Find("Player");
        mouseClickPlayer = playerObject.GetComponent<MouseClickPlayer>();
    }
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 100f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isRotating = !isRotating;
            if (mouseClickPlayer != null)
            {
                mouseClickPlayer.SpawnPrefab(LoliPrefab);
            }
        }
    }
    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}


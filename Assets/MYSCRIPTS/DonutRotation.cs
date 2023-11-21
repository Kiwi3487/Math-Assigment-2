using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutRotation : MonoBehaviour
{
    private bool isRotating = false;
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * -100f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isRotating = !isRotating;
        }
    }
}

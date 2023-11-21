using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicoreecAimShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    private int contactCount = 0;
    private int shotsFired = 0;
    private bool hasTouched = false;

    private void Update()
    {
        if (hasTouched && Input.GetMouseButtonDown(0) && shotsFired < contactCount + 1) // Change 0 to the appropriate button index
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 10f;
        
        shotsFired++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasTouched)
            {
                hasTouched = true;
            }
            else
            {
                shotsFired = 0;
                contactCount++;
            }
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class MouseClickPlayer : MonoBehaviour
{
    public float raycastDistance = 10f;
    public float prefabSpacing = 0.1f;

    public GameObject cookiePrefab;
    public GameObject donutPrefab;
    public GameObject mushroomPrefab;
    public GameObject gummiePrefab;
    public GameObject loliPrefab;
    public GameObject licoreecPrefab;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, raycastDistance);

            if (hit.collider != null)
            {
                GameObject prefabToSpawn = null;

                if (hit.collider.CompareTag("Cookie"))
                {
                    prefabToSpawn = cookiePrefab;
                    CookieTranslation cookieScript = hit.collider.GetComponent<CookieTranslation>();
                    if (cookieScript != null)
                    {
                        cookieScript.ToggleTranslation();
                    }
                }
                else if (hit.collider.CompareTag("Donut"))
                {
                    prefabToSpawn = donutPrefab;
                    DonutRotation donutRotationScript = hit.collider.GetComponent<DonutRotation>();
                    if (donutRotationScript != null)
                    {
                        donutRotationScript.ToggleRotation();
                    }
                }
                else if (hit.collider.CompareTag("Mushroom"))
                {
                    prefabToSpawn = mushroomPrefab;
                    MushroomGoBig mushroomScript = hit.collider.GetComponent<MushroomGoBig>();
                    if (mushroomScript != null)
                    {
                        mushroomScript.ScaleMushroom();
                    }
                }
                else if (hit.collider.CompareTag("Gummie"))
                {
                    prefabToSpawn = gummiePrefab;
                    GummieSpins gummieScript = hit.collider.GetComponent<GummieSpins>();
                    if (gummieScript != null)
                    {
                        gummieScript.ToggleRotation();
                    }
                }
                else if (hit.collider.CompareTag("Loli"))
                {
                    prefabToSpawn = loliPrefab;
                    LoliReverseRotation loliScript = hit.collider.GetComponent<LoliReverseRotation>();
                    if (loliScript != null)
                    {
                        loliScript.ToggleRotation();
                    }
                }
                else if (hit.collider.CompareTag("Licoreec"))
                {
                    prefabToSpawn = licoreecPrefab;
                    LicoreecAimShoot licoreecScript = hit.collider.GetComponent<LicoreecAimShoot>();
                    if (licoreecScript != null)
                    {
                        licoreecScript.ToggleShoot();
                    }
                }

                if (prefabToSpawn != null)
                {
                    SpawnPrefab(prefabToSpawn);
                }
            }
        }
        
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            if (spawnedObjects[i] != null)
            {
                float xOffset = i * prefabSpacing;
                spawnedObjects[i].transform.position = transform.position - transform.right * xOffset;
            }
        }
    }

    public void SpawnPrefab(GameObject prefab)
    {
        GameObject spawnedObject = Instantiate(prefab, transform.position - transform.forward * 2f, Quaternion.identity);
        spawnedObjects.Add(spawnedObject);
    }
}

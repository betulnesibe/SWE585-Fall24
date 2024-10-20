using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject objectPrefab;
    public Transform spawnPoint;
    public KeyCode spawnKey = KeyCode.Space;


    // Start is called before the first frame update
    void Start()
    {
        // to check the objectPrefab
        if (objectPrefab == null)
        {
            objectPrefab = GameObject.Find("SphereDefaultwScript");
        }

        // to check spawnPoint 
        if (spawnPoint == null)
        {
            GameObject defaultSpawn = GameObject.Find("SphereDefaultwScript");
            if (defaultSpawn != null)
            {
                spawnPoint = defaultSpawn.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            if (objectPrefab != null && spawnPoint != null)
            {
                Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                Debug.LogWarning("Object Prefab or Spawn Point is not assigned!");
            }
        }
    }
}

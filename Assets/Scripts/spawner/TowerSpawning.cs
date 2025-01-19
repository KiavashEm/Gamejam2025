using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour
{
    public GameObject tankPrefab; // Prefab for spawning tanks
    public GameObject towerPrefab; // Prefab for spawning towers
    private Transform selectedSpot; // The currently selected spot

    void Start()
    {
        // Assign button click events
        Button button1 = GameObject.Find("Button1").GetComponent<Button>();
        button1.onClick.AddListener(() => SpawnObject(tankPrefab)); // Link Button1 to spawn tankPrefab

        Button button2 = GameObject.Find("Button2").GetComponent<Button>();
        button2.onClick.AddListener(() => SpawnObject(towerPrefab)); // Link Button2 to spawn towerPrefab

        Debug.Log("TowerSpawner initialized");
    }

    public void SetSelectedSpot(Transform spot)
    {
        selectedSpot = spot;
        Debug.Log("Selected spot set to: " + spot.position);
    }

    void SpawnObject(GameObject objectToSpawn)
    {
        if (selectedSpot != null)
        {
            // Instantiate the object at the selected location spot
            GameObject spawnedObject = Instantiate(objectToSpawn, selectedSpot.position, Quaternion.identity);
            Debug.Log(objectToSpawn.name + " spawned at " + selectedSpot.position);

            // Check if the spawned object is correctly instantiated
            if (spawnedObject != null)
            {
                Debug.Log(objectToSpawn.name + " instantiated successfully");
            }
            else
            {
                Debug.LogError("Failed to instantiate " + objectToSpawn.name);
            }

            // Optionally, you can disable or hide the location spot after placing an object
            selectedSpot.gameObject.SetActive(false);

            // Clear the selected spot
            selectedSpot = null;
        }
        else
        {
            Debug.Log("No location spot selected");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to be spawned
    public float spawnInterval = 2f; // Time interval between spawns
    public Transform[] waypoints; // Array of waypoint objects

    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);

            // Instantiate the object at the spawner's position
            GameObject obj = Instantiate(objectToSpawn, transform.position, Quaternion.identity);

            obj.GetComponent<MoveWithoutRotation>().StartPlot(waypoints);
        }
    }
}

using UnityEngine;

public class LocationSpot : MonoBehaviour
{
    private TowerSpawner towerSpawner;

    void Start()
    {
        towerSpawner = Object.FindAnyObjectByType<TowerSpawner>(); // Updated method
    }

    void OnMouseDown()
    {
        if (towerSpawner != null)
        {
            towerSpawner.SetSelectedSpot(transform);
        }
    }
}


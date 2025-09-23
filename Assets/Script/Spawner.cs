using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private ScoreManager scoreManager; 

    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnRange = 5f;

    private float initialY;
    private GameObject currentObject;

    private void Start()
    {
        initialY = transform.position.y;
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    private void SpawnObject()
    {
        if (objectPrefab == null)
        {
            Debug.LogError("No prefab assigned to spawner!");
            return;
        }

        if (currentObject != null)
        {
            Destroy(currentObject);
        }

        Vector3 randomPos = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            initialY,
            0
        );

        currentObject = Instantiate(objectPrefab, randomPos, Quaternion.identity);

        BallPickup pickup = currentObject.GetComponent<BallPickup>();
        if (pickup != null)
        {
            pickup.SetScoreManager(scoreManager);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcSpawner : MonoBehaviour
{
    public GameObject[] obstacles;  
    public GameObject star;         
    public GameObject colorSwitcher; 

    public float spawnInterval = 2.0f;  // Time interval between each spawn
    public float spawnHeight = 10.0f;   // Height where the objects will spawn
    public float xRange = 3.0f;         // X position range for spawning

    private float timer;
    public Material[] colorMaterials; 
    private MainPlayer mainPlayerScript;

    public Camera mainCamera;
    public Transform mainPlayer;
    public float spawnOffsetAboveCamera = 2.0f;

    private bool lastSpawnWasColorSwitcher = false;  // Flag to track last spawned object

    void Start()
    {
        timer = spawnInterval;
        mainPlayerScript = mainPlayer.GetComponent<MainPlayer>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnRandomObject();
            timer = spawnInterval;
        }
    }

    void SpawnRandomObject()
    {
        float cameraTopEdge = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1, mainCamera.nearClipPlane)).y;
        float minSpawnY = Mathf.Max(cameraTopEdge + spawnOffsetAboveCamera, mainPlayer.position.y + 5f);
        // float spawnY = minSpawnY + Random.Range(0f, 3f); // Add randomness to the spawn height
        Vector3 spawnPosition = new Vector3(0, minSpawnY, 0);

        int randomChoice = Random.Range(0, 10);

        if (randomChoice <= 5)
        {
            // Spawn obstacle with random color
            SpawnObstacle(spawnPosition);
            lastSpawnWasColorSwitcher = false;
        }
        else if (randomChoice <= 8)
        {
            // Spawn star
            SpawnStar(spawnPosition);
            lastSpawnWasColorSwitcher = false;
        }
        else
        {
            // Spawn color switcher if last spawned was not a color switcher
            if (!lastSpawnWasColorSwitcher)
            {
                SpawnColorSwitcher(spawnPosition);
                lastSpawnWasColorSwitcher = true;
            }
            else
            {
                // If last was color switcher, spawn either a star or an obstacle
                if (Random.Range(0, 2) == 0)
                {
                    SpawnStar(spawnPosition);
                }
                else
                {
                    SpawnObstacle(spawnPosition);
                }
            }
        }
    }

    void SpawnObstacle(Vector3 spawnPosition)
    {
        GameObject spawnedObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPosition, Quaternion.identity);
        spawnedObstacle.tag = "Obstacle";
        SetRandomColor(spawnedObstacle);
        spawnedObstacle.SetActive(true);
    }

    void SpawnStar(Vector3 spawnPosition)
    {
        GameObject spawnedStar = Instantiate(star, spawnPosition, Quaternion.identity);
        spawnedStar.SetActive(true);
    }

    void SpawnColorSwitcher(Vector3 spawnPosition)
    {
        GameObject spawnedColorSwitcher = Instantiate(colorSwitcher, spawnPosition, Quaternion.identity);
        spawnedColorSwitcher.SetActive(true);
    }

    void SetRandomColor(GameObject obstacle)
    {
        if (colorMaterials.Length == 0) return;

        Material randomMaterial = colorMaterials[Random.Range(0, colorMaterials.Length)];
        Renderer obstacleRenderer = obstacle.GetComponent<Renderer>();
        if (obstacleRenderer != null)
        {
            obstacleRenderer.material = randomMaterial;
        }
    }
}

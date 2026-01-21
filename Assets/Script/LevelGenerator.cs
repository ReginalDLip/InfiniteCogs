using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    
    public GameObject[] platformPrefabs; 
    public Transform player;          

    [Header("Settings")]
    public int numberOfPlatforms = 10; 
    
    public float levelWidth = 3.5f;    

    public float minY = 0.8f;          
    public float maxY = 2.0f;          

    private Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = transform.position; 
        
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if (player.position.y > spawnPosition.y - (numberOfPlatforms * maxY))
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        spawnPosition.y += Random.Range(minY, maxY);
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);
        int randomIndex = Random.Range(0, platformPrefabs.Length);
        
        Instantiate(platformPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }
}
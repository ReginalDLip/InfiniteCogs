using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [Header("Settings")]
    public GameObject backgroundChunkPrefab; 
    public Transform player;                 
    
    public float chunkHeight = 20f;         
    public int chunksToSpawn = 2;          

    private float spawnY = 0f;               

    void Start()
    {
        for (int i = 0; i < chunksToSpawn; i++)
        {
            SpawnChunk();
        }
    }

    void Update()
    {
        if (player.position.y > spawnY - (chunkHeight * 2))
        {
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        Instantiate(backgroundChunkPrefab, new Vector3(0, spawnY, 10), Quaternion.identity);
        spawnY += chunkHeight;
    }
}
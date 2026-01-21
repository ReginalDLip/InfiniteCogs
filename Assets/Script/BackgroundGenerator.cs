using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [Header("Settings")]
    public GameObject backgroundChunkPrefab; // Masukkan Prefab BackgroundChunk di sini
    public Transform player;                 // Masukkan Player di sini
    
    public float chunkHeight = 20f;          // TINGGI Prefab Anda (Harus diukur!)
    public int chunksToSpawn = 2;            // Berapa banyak tumpukan awal

    private float spawnY = 0f;               // Posisi spawn berikutnya

    void Start()
    {
        // Spawn beberapa background di awal biar tidak kosong
        for (int i = 0; i < chunksToSpawn; i++)
        {
            SpawnChunk();
        }
    }

    void Update()
    {
        // Logika: Jika pemain sudah mendekati ujung background terakhir...
        // Kita spawn background baru di atasnya.
        // (spawnY - chunkHeight * 1.5f) artinya kita spawn SEBELUM pemain mentok ujung
        if (player.position.y > spawnY - (chunkHeight * 2))
        {
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        // Munculkan background di posisi spawnY
        Instantiate(backgroundChunkPrefab, new Vector3(0, spawnY, 10), Quaternion.identity);
        
        // Geser titik spawn selanjutnya ke atas sesuai tinggi background
        spawnY += chunkHeight;
    }
}
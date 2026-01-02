using UnityEngine;
using UnityEngine.SceneManagement; 
public class DeathFloor : MonoBehaviour
{
    [Header("Settings")]
    public float riseSpeed = 1.5f; 
    void Update()
    {
        transform.Translate(Vector2.up * riseSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over! Pemain termakan lava.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
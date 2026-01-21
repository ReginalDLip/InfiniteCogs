using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    private Transform player;
    private float destroyDistance = 50f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            if (transform.position.y < player.position.y - destroyDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    public Transform player;      
    public TMP_Text scoreText;    

    [Header("Settings")]
    public Vector3 offset = new Vector3(1.5f, 1f, 0); 

    void Update()
    {
        if (player != null && scoreText != null)
        {

            float currentHeight = player.position.y;
            scoreText.text = currentHeight.ToString("F2") + " m";
            scoreText.transform.position = player.position + offset;
        }
    }
}
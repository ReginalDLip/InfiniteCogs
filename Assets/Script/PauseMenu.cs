using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; 
    public bool isPaused = false;

    void Update()
    {
        // Jika tekan ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false); 
        Time.timeScale = 1f;         
        isPaused = false;
    }

    void Pause()
    {
        pausePanel.SetActive(true); 
        Time.timeScale = 0f;        
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;         
        SceneManager.LoadScene("MainMenu");
    }
}
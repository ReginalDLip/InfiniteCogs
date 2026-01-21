using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // Tarik Panel Pause ke sini
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
        pausePanel.SetActive(false); // Sembunyikan panel
        Time.timeScale = 1f;         // JALANKAN WAKTU LAGI (Normal)
        isPaused = false;
    }

    void Pause()
    {
        pausePanel.SetActive(true);  // Munculkan panel
        Time.timeScale = 0f;         // BEKUKAN WAKTU (Game berhenti)
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;         // PENTING: Kembalikan waktu sebelum pindah scene
        SceneManager.LoadScene("MainMenu");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool Paused = false;
    public GameObject pauseMenuUi;
    // Start is called before the first frame update
    public void pause()
    {
        if (!Paused)
        {
            pauseMenuUi.SetActive(true);
            Paused = true;
            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            pauseMenuUi.SetActive(false);
            Paused = false;
            Time.timeScale = 1;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        Paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }


    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            pause();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private bool Paused = false;
    // Start is called before the first frame update
    public void pause()
    {
        if (!Paused)
        {
            Paused = true;
            Time.timeScale = 0;
        }
        else
        {
            Paused = false;
            Time.timeScale = 1;
        }
    }


    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            pause();
        }
    }
}

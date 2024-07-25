using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public Button BackButton;
    // Start is called before the first frame update


    public void GoToOptionsMenu()
    {
        BackButton.Select();
    }
}

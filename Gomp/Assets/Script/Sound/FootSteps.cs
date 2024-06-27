using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    // Start is called before the first frame update

    public Player player;
    public GameObject Footsteps;
    void Start()
    {
        Footsteps.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isMoving && player.isGrounded)
        {
            Footsteps.SetActive(true);
        }
        else 
        {
            Footsteps.SetActive(false);
        }
    }
}

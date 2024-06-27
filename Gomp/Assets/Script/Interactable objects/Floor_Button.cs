using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Button : MonoBehaviour
{

    public GameObject buttonPressed;
    public bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        buttonPressed.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))

        {
            this.gameObject.SetActive(false);
            buttonPressed.SetActive(true);
            activated = true;

        }
    }
}

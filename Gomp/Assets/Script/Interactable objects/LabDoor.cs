using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabDoor : MonoBehaviour
{

    public Floor_Button Button;
    public GameObject TopSlider;
    public GameObject BottomSlider;

    public float speed;
    private Vector2 topEndPos;
    private Vector2 botEndPos;

    // Start is called before the first frame update
    void Start()
    {
        topEndPos = new Vector2(TopSlider.transform.position.x, TopSlider.transform.position.y + 1.355f);
        botEndPos = new Vector2(BottomSlider.transform.position.x, BottomSlider.transform.position.y - 1.49f);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Button.activated) 
        {
            TopSlider.transform.position = Vector2.MoveTowards(TopSlider.transform.position, topEndPos, speed * Time.deltaTime);
            BottomSlider.transform.position = Vector2.MoveTowards(BottomSlider.transform.position, botEndPos, speed * Time.deltaTime);
        }

    }
}

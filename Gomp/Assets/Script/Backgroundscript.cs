using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}

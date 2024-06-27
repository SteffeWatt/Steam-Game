using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretZones : MonoBehaviour
{

    public Tilemap tM;
    private Color tileColor;

    // Start is called before the first frame update
    void Start()
    {
        tileColor = this.gameObject.GetComponent<Tilemap>().color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("enter secret");
            //this.gameObject.GetComponent<Tilemap>().color = new Color(tileColor.r, tileColor.g, tileColor.b, 0.25f);
            Fade(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("Leave secret");
            //this.gameObject.GetComponent<Tilemap>().color = new Color(tileColor.r, tileColor.g, tileColor.b, 1f);
            Fade(false);
        }

    }

    private void Fade(bool fade)
    {
        if (fade)
        {
            StartCoroutine(FadeToTransperency(1f));
        }
        else
        {
            StartCoroutine(FadeToFullColor(1f));
        }
    }

    private IEnumerator FadeToTransperency(float fadeTime)
    {
        float startTime = Time.time;
        float endTime = startTime + fadeTime;

        while (Time.time < endTime)
        {
            float currentime = (Time.time - startTime) / 1f;
            this.gameObject.GetComponent<Tilemap>().color = new Color(tileColor.r, tileColor.g, tileColor.b, Mathf.Lerp(tileColor.a, 0f, currentime));
            yield return null;
        }
    }

    private IEnumerator FadeToFullColor(float fadeTime)
    {
        float startTime = Time.time;
        float endTime = startTime + fadeTime;

        while (Time.time < endTime)
        {
            float currentime = (Time.time - startTime) / 1f;
            this.gameObject.GetComponent<Tilemap>().color = new Color(tileColor.r, tileColor.g, tileColor.b, Mathf.Lerp(0f, 1f, currentime));
            yield return null;
        }
    }
}

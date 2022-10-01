using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public AudioClip t_Audio;

    // Start is called before the first frame update
    void Start()
    {

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = t_Audio;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

        if (Input.GetMouseButton(0))
        {

            GetComponent<AudioSource>().Play();

        }
    }
}

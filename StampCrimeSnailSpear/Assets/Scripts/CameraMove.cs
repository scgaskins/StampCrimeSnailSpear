using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    public float boundaryPercent;

    private float lBound;
    private float rBound;
    // Start is called before the first frame update
    void Start()
    {
        lBound = boundaryPercent * Camera.main.pixelWidth;
        rBound = Camera.main.pixelWidth - lBound;
    }

    void FixedUpdate()
    {
        if (player)
        {
            Vector3 spriteLoc = player.transform.position;

            Vector3 pos = transform.position;

            if(spriteLoc.x < lBound)
            {
                pos.x -= lBound - spriteLoc.x;
            } else if(spriteLoc.x > rBound)
            {
                pos.x += spriteLoc.x - rBound;
            }

            transform.position = pos;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    public float boundaryPercent;

    private float lBound;
    private float rBound;
    private float uBound;
    private float dBound;

    // Start is called before the first frame update
    void Start()
    {
        lBound = boundaryPercent * Camera.main.pixelWidth;
        rBound = Camera.main.pixelWidth - lBound;
        dBound = Camera.main.pixelHeight * boundaryPercent;
        uBound = Camera.main.pixelHeight - dBound;
    }

    void FixedUpdate()
    {
        if (player)
        {
            Vector3 spriteLoc = Camera.main.WorldToScreenPoint(player.transform.position);

            Vector3 pos = transform.position;

            if(spriteLoc.x < lBound)
            {
                pos.x -= lBound - spriteLoc.x;
            } else if(spriteLoc.x > rBound)
            {
                pos.x += spriteLoc.x - rBound;
            }
            if (spriteLoc.y > uBound)
            {
                pos.y += spriteLoc.y - uBound;
            } else if (spriteLoc.y < dBound)
            {
                pos.y -= dBound - spriteLoc.y;
            }

            transform.position = pos;
        }
    }
}

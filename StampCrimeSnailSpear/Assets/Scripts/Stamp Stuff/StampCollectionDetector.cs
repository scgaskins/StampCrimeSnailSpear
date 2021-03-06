using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampCollectionDetector : MonoBehaviour
{

    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Snail")
        {
            particles.transform.position = gameObject.transform.position;
            Instantiate(particles);
            GameManager.Instance.IncrementScore(1);
            GameManager.Instance.IncrementStampCount(-1);
            Destroy(gameObject);
        }
    }
}


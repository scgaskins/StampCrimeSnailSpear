using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampCollectionDetector : MonoBehaviour
{

    public GameObject particles;
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = particles.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Snail")
        {
            GameManager.Instance.IncrementScore(1);
            GameManager.Instance.IncrementStampCount(-1);
            Destroy(gameObject);
            ps.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageParticles : MonoBehaviour
{
    private ParticleSystem ps;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        source = gameObject.GetComponent<AudioSource>();
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.isStopped)
        {
            Destroy(gameObject);
        }
    }
}

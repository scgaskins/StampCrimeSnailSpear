using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStamps : MonoBehaviour
{
    //Added these variables so that we can adjust the range of stam spawning if need be when we create the world
    public float xRandom = 15f;
    public float yRandom = 15f;

    public GameObject[] guards;
    public GameObject stamp;
    public int maxStampCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetStampCount() < maxStampCount)
        {
            SpawnStamp();
            Debug.Log("Spawned a stamp");
        }
    }

    private void SpawnStamp()
    {
        GameObject stampInstance = Instantiate(stamp);
        stampInstance.transform.position = new Vector2(Random.Range(-xRandom, xRandom), Random.Range(-yRandom, yRandom));
        Vector2 stampPos = stamp.transform.position;
        GameObject guardInstance = Instantiate(guards[Random.Range(0, 2)]);
        guardInstance.transform.position = new Vector2(stampPos.x + (Random.Range(-3, 3)), stampPos.y + (Random.Range(-3, 3)));
        GameManager.Instance.IncrementStampCount(1);
    }
}

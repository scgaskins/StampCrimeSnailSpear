using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStamps : MonoBehaviour
{

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
        stampInstance.transform.position = new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f));
        GameManager.Instance.IncrementStampCount(1);
    }
}

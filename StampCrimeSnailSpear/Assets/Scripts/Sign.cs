using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public string text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Snail")
        {
            Debug.Log("Player entered sign");
            GameManager.Instance.StartDialog(text);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Snail")
        {
            Debug.Log("Player left sign");
            GameManager.Instance.HideDialog();
        }
    }
}

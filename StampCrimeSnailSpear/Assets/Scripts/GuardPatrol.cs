using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardPatrol : MonoBehaviour
{
    public float duration;
    public float distance;

    private Vector2 originalPosition;
    private float direction;
    private Vector2 targetPosition;
    private int ax = -1;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        direction = -1.0f;
        targetPosition = new Vector2(transform.position.x + (direction * distance), transform.position.y);
        StartCoroutine("LerpPosition");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeTargetPosition()
    {
        //Attempted to vary the patrol so that they circle around their stamp.
        switch (ax)
        {
            case 0:
                targetPosition = new Vector2(originalPosition.x + (direction * distance), originalPosition.y);
                break;
            case 1:
                targetPosition = new Vector2(originalPosition.x, originalPosition.y + (direction * distance));
                break;
            case 2:
                targetPosition = new Vector2(originalPosition.x, originalPosition.y - (direction * distance));
                break;
            case 3:
                targetPosition = new Vector2(originalPosition.x + (direction * distance), originalPosition.y);
                ax = 0;
                break;
            default:
                Debug.Log("guard patrol went wrong");
                break;
        }
            
        
        
            
        
    }

    IEnumerator LerpPosition()
    {
        while (true)
        {
            float time = 0;
            Vector2 startPosition = transform.position;

            while (time < duration)
            {
                transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
            direction = -direction;
            ax++;
            ChangeTargetPosition();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Snail")
        {
            SceneManager.LoadScene("Game_Over");
        }
    }
}

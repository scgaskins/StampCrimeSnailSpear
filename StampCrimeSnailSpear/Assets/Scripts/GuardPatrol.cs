using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    public float duration;
    public float distance;

    private Vector2 originalPosition;
    private float direction;
    private Vector2 targetPosition;

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
        targetPosition = new Vector2(originalPosition.x + (direction * distance), originalPosition.y);
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
            ChangeTargetPosition();
        }
    }
}

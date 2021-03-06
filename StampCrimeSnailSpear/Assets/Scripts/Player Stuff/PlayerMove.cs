using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2d;

    public Sprite leftSprite;
    public Sprite rightSprite;

    private SpriteRenderer spriteRenderer;

    public float runSpeed = 2f;
    private float moveLimiter = 0.7f;

    private float horizontal;
    private float vertical;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if(horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        if (horizontal > 0)
        {
            spriteRenderer.sprite = rightSprite;
        } else if (horizontal < 0)
        {
            spriteRenderer.sprite = leftSprite;
        }
        rb2d.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}

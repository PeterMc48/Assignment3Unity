using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 10f;

    private MainMenu menu;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();    
    }
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(2.5f,.5f);
        menu = FindObjectOfType<MainMenu>();
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        gameStarted(menu.getGameStarted());
    }

    public void gameStarted(bool started)
    {
        if (started)
        {
            touchMove();
        }

    }

    private void FixedUpdate() 
    {
            
    }

    void touchMove()
    {
        if(Input.touchCount > 0)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);

            if(touchPos.x < 0)
            {
                rb.velocity = Vector2.left * moveSpeed;
            }
            else 
            {
                rb.velocity = Vector2.right * moveSpeed;
            }

        }
        else
        {   
            rb.velocity = Vector2.zero;
        }
    }

    internal void reset()
    {
        transform.position = new Vector2(0, -3.5f);
        transform.localScale = new Vector2(2.5f, .5f);
        rb.velocity = Vector2.zero;
    }

    internal void LargerPaddle()
    {
        transform.localScale = new Vector2(3.5f, .5f);
    }

  


}

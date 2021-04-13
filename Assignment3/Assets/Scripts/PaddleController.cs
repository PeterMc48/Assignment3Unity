using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 10f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();    
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        touchMove();
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
}

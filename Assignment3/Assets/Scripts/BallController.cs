using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    [SerializeField]
    private float bounceForce = 6f;

    bool gameStarted;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();    
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {   
        if(!gameStarted)
        {
            if(Input.touchCount>0)
            {
                Bounce();
                gameStarted = true;
                GameManger.instance.gameStart();
            }
        }
        

        outOfBounds();
    }

    void Bounce()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-2,6),1);

        rb.AddForce(randomDirection * bounceForce,ForceMode2D.Impulse);
    }
    void outOfBounds()
    {
        if(transform.position.y < -6)
        {
            GameManger.instance.Restart();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Paddle")
        {
            GameManger.instance.ScoreUp();
        }
    }
    
}

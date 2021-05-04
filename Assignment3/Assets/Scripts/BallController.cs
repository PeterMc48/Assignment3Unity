using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;


    [SerializeField]
    private float bounceForce = 6f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();    
    }
    void Start()
    {
        reset();
       
    }

    // Update is called once per frame
    void Update()
    {   

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
            rb.AddForce(rb.velocity.normalized * 5, ForceMode2D.Impulse);
        }
    }

    internal void reset()
    {
        transform.position = new Vector2(0, -2.78f);
        rb.velocity = Vector3.zero;
    }
    public void gameStarted(bool started)
    {
        if (started)
        {
            Bounce();
            GameManger.instance.gameStart();
        }
        
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    int score;
    public Text scoreText;

    private BallController ball;

    private PaddleController paddle;

    public GameObject Menu;

    private MainMenu menu;


    
    private void Awake() {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        
        ball = FindObjectOfType<BallController>();
        paddle = FindObjectOfType<PaddleController>();
        menu = Menu.GetComponent<MainMenu>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        int number = UnityEngine.Random.Range(1, 3);

        //print("the score is " +score);
        if (score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            //print("the high score is "+highScore.text);
        }
        

        if (number == 1)
        {
            //unity ad
            AdManager.instance.ShowIntersititialAd();

        }
        else
        {
            AdManager.instance.GameOver();
        }
        
        resetScene();

     
    }

    private void resetScene()
    {
        score = 0;
        paddle.reset();
        ball.reset();
        Menu.SetActive(true);
        menu.ActiveButtons();
        menu.gameEnded();
        scoreText.text = score.ToString();
        scoreText.gameObject.SetActive(false);
    }

    public void ScoreUp(){
        
        scoreText.text = score.ToString();
        score++;
    }

    public void gameStart()
    {
        
        scoreText.gameObject.SetActive(true);
    }
    
}

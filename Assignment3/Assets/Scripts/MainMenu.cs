using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    private int rounds;
    
    public GameObject reward;

    int highScore1;

    public Text highScore;

    private BallController ball;

    private PaddleController paddle;

    private GoogleAd ga;

    UnityRewards ur;

    bool gameStarted = false;

    Button[] buttons;

    void Start()
    {
        highScore1 = PlayerPrefs.GetInt("HighScore", 0);
        //print("the highscore is "+highScore1);
        highScore.text = highScore1.ToString();
        ball = FindObjectOfType<BallController>();
        paddle = FindObjectOfType<PaddleController>();
        buttons = FindObjectsOfType<Button>();
        ga = FindObjectOfType<GoogleAd>();
        ur = FindObjectOfType<UnityRewards>();
    }
    public void PlayGame()
    {
        gameStarted = true;
        ball.gameStarted(gameStarted);
        gameObject.SetActive(false);
        foreach (Button b in buttons)
        {
            b.enabled = false;
        }
        rounds++;

        if (rounds == 3)
        {
            //make reward visible
            reward.SetActive(true);
            rounds = 0;
        }

    }
    public bool getGameStarted()
    {
        return gameStarted;
    }
    public void getReward()
    {
        int number = 2;// Random.Range(1, 3);

        if(number == 1)
        {
            //unity ad
            ur.ShowRewardedVideo();
           
        }
        else
        {
            //google add
            ga.ShowRewardedVideo();
        }


        //hide button for 3 rounds
        reward.SetActive(false);
    }

    internal void gameEnded()
    {
        gameStarted = false;
    }

    internal void ActiveButtons()
    {
        foreach(Button b in buttons)
        {
            b.enabled = true;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    int score;
    public Text scoreText;

    public Text highScore;

    public GameObject mainMenu;
    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {

        print("the score is " +score);
        if(score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();  
            //print("the high score is "+highScore.text);
        }
        
        SceneManager.LoadScene("Game");
        //highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();

        AdManager.instance.ShowIntersititialAd();
    }
    
    public void ScoreUp(){
        
        scoreText.text = score.ToString();
        score++;
    }

    public void gameStart()
    {
        mainMenu.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}

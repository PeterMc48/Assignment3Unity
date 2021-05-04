using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
using UnityEngine.SceneManagement;

public class PlayServices : MonoBehaviour
{
    int score;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        try
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            Social.localUser.Authenticate((bool success) => { 
                if(success)
                {
                    SceneManager.LoadScene("LeaderboardUI");
                }
            });
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public static void AddScoreToLeaderBoard(string hs)
    {
        PlayerPrefs.SetInt("currentScore", int.Parse(hs));
        if (PlayerPrefs.GetInt("currentScore", 0) < PlayerPrefs.GetInt("HighScore", 0))
        {
            return;
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("currentScore", 0));
        }
        Social.ReportScore(PlayerPrefs.GetInt("HighScore", 1), GPGSIds.leaderboard_leaderboard, (bool success) =>
        {
            print(PlayerPrefs.GetInt("HighScore", 1) + " added to leaderboard");
        });
    }
    public void OpenLeaderBoard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_leaderboard);
    }

    public static void unlockAchievement()
    {
        if(Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_achievement, 100f, success => { });
        }
    }

    public static void showAchievement()
    {
        if(Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

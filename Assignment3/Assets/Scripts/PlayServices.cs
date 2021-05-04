using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;

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
            Social.localUser.Authenticate((bool success) => { });
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public void AddScoreToLeaderBoard()
    {
        if (Social.localUser.authenticated)
        {
            //Social.ReportScore(playerScore, "", success => { });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

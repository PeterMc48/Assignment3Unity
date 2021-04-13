using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    string gameid = "4088569";
    bool testmode = true;

    public static AdManager instance;

    public string surfacingId = "bannerPlacement";
    // Start is called before the first frame update
    
    private void Awake() {
        instance = this;
    }

    void Start()
    {
        Advertisement.Initialize(gameid,testmode);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowIntersititialAd()
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    IEnumerator ShowBannerWhenInitialized () {
        while (!Advertisement.isInitialized) {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show (surfacingId);

        
    }


       
    
}

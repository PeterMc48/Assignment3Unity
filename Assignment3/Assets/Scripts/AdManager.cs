using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;


public class AdManager : MonoBehaviour
{
    string gameid = "4088569";
    bool testmode = true;

    int number;
    
    private BannerView bannerView;

    private InterstitialAd interstitial;

    public static AdManager instance;

    public string surfacingId = "bannerPlacement";
    
    // Start is called before the first frame update

    private void Awake() {
        instance = this;
        number = Random.Range(1, 3);
    }

    void Start()
    {
        Advertisement.Initialize(gameid,testmode);
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();
        getBanner();


    }
    void getBanner()
    {
        if (number == 1)
        {
            StartCoroutine(ShowBannerWhenInitialized());

        }
        else
        {
            this.RequestGoogleBanner();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RequestGoogleBanner()
    {

        string adUnitId = "ca-app-pub-4520951121950443/4728397477";

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);

    }
    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-4520951121950443/4728397477";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
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
            yield return new WaitForSeconds(1.5f);
        }
        Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show (surfacingId);

        
    }
    private void RequestInterstitial()
    {

        string adUnitId = "ca-app-pub-4520951121950443/7505963425";

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);

    }

    public void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = true;
    [SerializeField] private GameObject adBonusButton;
    private string adsID = "4701281";
    private string banner = "My_Banner";

    private void Awake(){
        Advertisement.AddListener(this);
        Advertisement.Initialize(adsID, testMode);
        StartCoroutine(CheckCoinBonusButton());
    }
    void Start()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(banner);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnUnityAdsDidError(string message){
        Time.timeScale = 1f;
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult){
        if(showResult == ShowResult.Finished){
            Time.timeScale = 1f;
            CoinController.AddCoin(300);
            adBonusButton.SetActive(false);
        }else if(showResult == ShowResult.Skipped){
            Time.timeScale = 1f;
        }else if(showResult == ShowResult.Failed){
            Time.timeScale = 1f;
        }
    }
    public void OnUnityAdsDidStart(string placementId){
        Time.timeScale = 0f;
    }
    public void OnUnityAdsReady(string placementId){

    }
    public static void ShowVideo(string placementId){
        if(Advertisement.IsReady()) Advertisement.Show(placementId);
        else Debug.Log("Video not ready");
    }
    IEnumerator CheckCoinBonusButton(){
        yield return new WaitForSeconds(60f);
        if(!adBonusButton.activeSelf){
            adBonusButton.SetActive(true);
        }
        StartCoroutine(CheckCoinBonusButton());
    }
    public void PressedAdButton(){
        ShowVideo("Rewarded_Android");
    }
}

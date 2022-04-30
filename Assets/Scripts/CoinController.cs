using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    [SerializeField] private int startCoin;
    private static int coin;
    [SerializeField] private Text coinText;
    private void Awake(){
        coin = startCoin;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coin.ToString();
    }
    public static int GetCoinValue(){
        return coin;
    }
    public static void AddCoin(int value){
        coin += value;
    }
    public static bool SubtractCoin(int value){
        if(value > coin) return false;
        coin -= value;
        return true;
    }
}

using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    private int coins;
    [SerializeField] private TMP_Text coinsDisplays;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void OnGUI()
    {
        coinsDisplays.text = coins.ToString();
    }



    public void ChangeCoins(int amount)
    { 
        coins = amount; 
    
    }



}
    
  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
   
    public TextMeshProUGUI coinUI;
    public PlayerData playerData;

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            playerData.playerCoins = 0;
            Debug.Log("Resetting coins");
        }
    }
    void Update()
    {
        coinUI.text = "Coins: " + playerData.playerCoins;
    } 
}

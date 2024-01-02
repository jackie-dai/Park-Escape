using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class BalloonManager : MonoBehaviour
{
    #region Public Static Variables
    public static string currentColor;
    public string CurrentColor
    {
        get
        {
            return currentColor;
        }
    }
    public int totalBalloons;
    public static string[] colorOptions = { "Red", "Blue", "Yellow" };
    public static int countToWin;
    public int TotalBalloons
    {
        get
        {
            return totalBalloons;
        }
    }
    public int[] balloonCounts = { 0, 0, 0 };
    #endregion

    #region Private Variables
    [SerializeField] private TextMeshProUGUI destroyUI;
    private bool dataLoaded;
    #endregion

    #region Unity Functions
    void Awake()
    {
        dataLoaded = false;
    }

    void Start()
    {
       
    }

    void Update()
    {
        if (totalBalloons == 10 && !dataLoaded)
        {
            loadData();
            dataLoaded = true;
        }
     }

    #endregion

    #region User Functions

    private void loadData()
    {
        System.Random rand = new System.Random();
        int randomNum = rand.Next(colorOptions.Length);
        while (balloonCounts[randomNum] == 0)
        {
            randomNum = rand.Next(colorOptions.Length);
        }

        Debug.Log("Balloon Manager's Total Balloons: " + totalBalloons);
        Debug.Log("Balloon Manager's red coumt: " + balloonCounts[0] + ", " + balloonCounts[1] + "," + balloonCounts[2]);
        string destroyText = "Destroy all of the " + colorOptions[randomNum] + " balloons";
        destroyUI.text = destroyText;
        countToWin = balloonCounts[randomNum];
        currentColor = colorOptions[randomNum];
    }

    public void AddBalloon(int amount)
    {
        totalBalloons += amount;
        Debug.Log("balloon added");
    }

    public void AddColorCount(int index, int amount)
    {
        balloonCounts[index] += amount;
    }

    public void ReduceCount()
    {
            countToWin -= 1;
            Debug.Log("Count to win: " + countToWin);
            if (countToWin <= 0)
            {
                SceneManager.LoadScene("Main_Coin");
            }
    }

    #endregion
}

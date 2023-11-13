using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject newspaperUI;
    private bool displayed = false;
    private Rigidbody playerRB;
    RigidbodyConstraints originalConstraints;
    #endregion

    private void Start()
    {
        GameObject playerObj = GameObject.Find("Player");
        playerRB = playerObj.GetComponent<Rigidbody>();
        originalConstraints = playerRB.constraints;
        if (playerRB == null)
        {
            Debug.Log("Cannot find player"); //error checking
        }
    }

    /* Called by interact.cs */
    public void Activate()
    {
        HandleNewspaperDisplay();
    }

    /* Toggle newspaper UI */ 
    private void HandleNewspaperDisplay()
    {
        if (!displayed)
        {
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
            newspaperUI.SetActive(true);
            displayed = true;
        } else
        {
            playerRB.constraints = originalConstraints;
            newspaperUI.SetActive(false);
            displayed = false;
        }
    }
}

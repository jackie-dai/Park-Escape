using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Cat : MonoBehaviour
{
    #region Variables
    public DialogueRunner dialogue;
    private bool isActive = false;

    private Transform boothPosition;
    #endregion

    private void Awake()
    {
        boothPosition = gameObject.transform.Find("BoothPosition");
        if (boothPosition == null)
        {
            Debug.Log("Cannot find boothPosition");
        }
    }
    public void Activate()
    {
        if (!isActive)
        {
            ToggleOnDialogue();
            Debug.Log("Node: " + dialogue.CurrentNodeName);
        } else
        {
            ToggleOffDialogue();
        }
    }

    [YarnCommand("move_to_booth")] // Allows yarn scripts to call this function
    public void MoveToBooths()
    {
        Debug.Log("i am moving meow");
        transform.position = boothPosition.position;
        ToggleOffDialogue();
    }

    private void ToggleOnDialogue()
    {
        
        dialogue.gameObject.SetActive(true);
        isActive = true;
    }

    private void ToggleOffDialogue()
    {
        dialogue.gameObject.SetActive(false);
        isActive = false;
    }



}

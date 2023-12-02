using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject InventoryCanvas;

    private bool isVisible = false;
    #endregion
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isVisible)
            {
                InventoryCanvas.SetActive(false);
                isVisible = false;
            } else
            {
                InventoryCanvas.SetActive(true);
                isVisible = true;
            }
        }
    }
}

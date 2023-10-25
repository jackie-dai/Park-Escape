using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    // Define a variable to check if the item is currently being held
    private bool isHeld = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHeld)
            {
                // If the item is already held, drop it
                DropItem();
            }
            else
            {
                // If the item is not held, pick it up
                PickUpItem();
            }
        }
    }

    // Function to pick up the item
    void PickUpItem()
    {
        // You can customize this part to implement the item pickup logic
        // For example, disabling the item's collider and setting its position to the player's hand.
        // Here, we'll simply deactivate the object.
        gameObject.SetActive(false);
        isHeld = true;
    }

    // Function to drop the item
    void DropItem()
    {
        // You can customize this part to implement the item drop logic
        // For example, enabling the item's collider and resetting its position.
        // Here, we'll simply reactivate the object.
        gameObject.SetActive(true);
        isHeld = false;
    }
}

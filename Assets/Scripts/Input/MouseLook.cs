using UnityEngine;
using Yarn.Unity;

public class MouseLook : MonoBehaviour
{
    public Camera camera;
    public float rotationSpeed = 2f;
    private bool dialogueFinished = false;
    void Update()
    {
        if (dialogueFinished)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");
            float x = inputX * rotationSpeed;
            float y = -(inputY * rotationSpeed);

            Vector3 rotation = transform.rotation.eulerAngles + new Vector3(0, inputX * rotationSpeed, -(inputY * rotationSpeed));
            rotation = new Vector3(0, Mathf.Clamp(rotation.y, 40, 140), Mathf.Clamp(rotation.z, 16, 90));
            transform.rotation = Quaternion.Euler(rotation);
        }
       
    }

    [YarnCommand("balloon_dialogue")]
    public void balloonDialogue()
    {
        dialogueFinished = true;
    }
}
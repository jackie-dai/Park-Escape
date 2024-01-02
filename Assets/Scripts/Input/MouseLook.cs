using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Camera camera;
    public float rotationSpeed = 2f;
    void Update()
    {
        /*        Vector3 mousePos = Input.mousePosition;
                mousePos.z = camera.nearClipPlane;
                mousePos = camera.ScreenToWorldPoint(mousePos);
                Debug.Log("Mouse Position: " + mousePos);

                //transform.LookAt(Input.mousePosition);
                transform.LookAt(2 * Input.mousePosition - transform.position);*/

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float x = inputX * rotationSpeed;
        float y = -(inputY * rotationSpeed);
      
        Vector3 rotation = transform.rotation.eulerAngles + new Vector3(0, inputX * rotationSpeed, -(inputY * rotationSpeed));
        rotation = new Vector3(0, Mathf.Clamp(rotation.y, 40, 140), Mathf.Clamp(rotation.z, 16, 90));
        transform.rotation = Quaternion.Euler(rotation);
    }
}
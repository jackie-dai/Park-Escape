using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rope : MonoBehaviour
{
    private Vector3 endDestination;
    private Vector3 startPosition;
    private float incrementalPosition;
    private float lerpDuration = 1f;

    private void Awake()
    {
        startPosition = transform.position;
        endDestination = transform.GetChild(0).transform.position;
        incrementalPosition = (startPosition.y - endDestination.y) / 5;
    }

    public void MoveDown()
    { 
        StartCoroutine(Move(new Vector3(transform.position.x, transform.position.y - incrementalPosition, transform.position.z)));
    }

    IEnumerator Move(Vector3 targetLocation)
    {

        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(transform.position, targetLocation, Time.deltaTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetLocation;
     
    }

}

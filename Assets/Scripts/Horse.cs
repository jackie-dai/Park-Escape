using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    #region Instance Variables
    Vector3 startPos;
    Quaternion startRot;

    [SerializeField]
    GameObject targetLocation;

    [SerializeField]
    float moveDuration = 2f;

    bool atStartingLocation;
    #endregion

    void Awake()
    {
        startPos = transform.position;
        startRot = transform.rotation;

        // for determining whether to move towards targetPos or startPos
        atStartingLocation = true;
    }

    public void Move()
    {
        Debug.Log("Horse start move");
        if (atStartingLocation)
        {
            StartCoroutine(LerpPosition(startPos, targetLocation.transform.position, startRot, targetLocation.transform.rotation, moveDuration));
            atStartingLocation = false;
        } else
        {
            StartCoroutine(LerpPosition(targetLocation.transform.position, startPos, targetLocation.transform.rotation, startRot, moveDuration));
            atStartingLocation = true;
        }
    }

    IEnumerator LerpPosition(Vector3 startPosition, Vector3 targetPosition, Quaternion startRotation, Quaternion targetRotation, float duration)
    {
       
        float time = 0;
        while (time < duration)
        {
            //Debug.Log(transform.position);
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }
}

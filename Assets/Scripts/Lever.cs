using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] Horse selectedHorse;

    public void Activate()
    {
        selectedHorse.Move();
    }
}

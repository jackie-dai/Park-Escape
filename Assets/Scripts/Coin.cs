using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public PlayerData playerData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerData.playerCoins += 1;
            Destroy(this.gameObject);
        }
    }
}

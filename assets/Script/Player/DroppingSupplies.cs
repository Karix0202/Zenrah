using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingSupplies : MonoBehaviour
{
    
    private int quantity;

    private void Start()
    {
        quantity = Random.Range(1, 3);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Player")
        {
            PlayerGun player = c.GetComponent<PlayerGun>();
            player.bombCount += quantity;
        }
    }
}

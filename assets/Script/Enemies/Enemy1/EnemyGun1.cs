using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGun1 : MonoBehaviour 
{
    #region CLASS_VARIAVLES

    //public
    public GameObject enemyBullet;
    public GameObject enemyPoint;
    public int speed = 1;

    #endregion

    void Start()
    {
        InvokeRepeating("FireEnemyBullet", 0.6f, 1.5f);
    }

    void FireEnemyBullet()
    {
        GameObject player = GameObject.Find("Player");

        if(player != null)
        {
            GameObject bullet = (GameObject)Instantiate(enemyBullet);

            bullet.transform.position = transform.position;
            Vector2 position = transform.position;
            Vector2 direction = new Vector2(0, -1);

            bullet.GetComponent<EnemyBullet1>().SetDirection(direction);
        }
        
    }

}

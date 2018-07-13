using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGun2 : MonoBehaviour 
{

    #region CLASS_VARIAVLES

    //public
    public GameObject enemyPoint1;
    public GameObject enemyPoint2;
    public GameObject enemyBullet;
    public int speed = 1;

    #endregion

    void Start () 
	{
        InvokeRepeating("FireEnemyBullet", 0.6f, 1.5f);
    }

    void FireEnemyBullet()
    {
        GameObject player = GameObject.Find("Player");

        if(player != null)
        {
            GameObject bullet = (GameObject)Instantiate(enemyBullet);
            GameObject bullet2 = (GameObject)Instantiate(enemyBullet);

            bullet.transform.position = enemyPoint1.transform.position;
            bullet2.transform.position = enemyPoint2.transform.position;

            Vector2 position = transform.position;
            Vector2 direction = new Vector2(0, -1);

            bullet.GetComponent<EnemyBullet1>().SetDirection(direction);
            bullet2.GetComponent<EnemyBullet1>().SetDirection(direction);
        }
    
    }

}

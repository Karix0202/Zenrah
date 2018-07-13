using System.Collections;
using UnityEngine;

public class DeviceController : MonoBehaviour 
{

	#region CLASS_VARIAVLES
    public static bool isMobile = false;
	#endregion

	void Start () 
	{
#if UNITY_ANDROID
        isMobile = true;
#endif

        if(isMobile == true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.localScale = new Vector2(2.3f, 2.3f);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject e in enemies)
            {
                e.transform.localScale = new Vector2(2.3f, 2.3f);
            }

            GameObject[] playerB = GameObject.FindGameObjectsWithTag("PlayerBullet");
            foreach (GameObject pb in playerB)
            {
                pb.transform.localScale = new Vector2(2.3f, 2.3f);
            }

            GameObject[] bomb = GameObject.FindGameObjectsWithTag("Bomb");
            foreach (GameObject b in bomb)
            {
                b.transform.localScale = new Vector2(2.3f, 2.3f);
            }

            GameObject[] enemyB = GameObject.FindGameObjectsWithTag("EnemyBullet");
            foreach (GameObject eb in enemyB)
            {
                eb.transform.localScale = new Vector2(2.3f, 2.3f);
            }
        }
    }

}

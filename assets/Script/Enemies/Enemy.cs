using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{

    #region CLASS_VARIAVLES

    public float speed = 8f;

    public GameObject explosion;
    public GameObject littleExplosion;

    public int type;

    public int fullHP;
    private int health;

    private bool destroyedByPlayer;

	#endregion

    void Start()
    {
        health = fullHP;
    }

    void Update()
    {

        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

        if (health <= 0)
            DestoryShip();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "Player") || (col.tag == "PlayerBullet"))
        {
            GameObject lex = (GameObject)Instantiate(littleExplosion);
            lex.transform.position = transform.position;
            lex.transform.rotation = transform.rotation;
            Destroy(lex, 2);
            switch (type)
            {
                case 1:
                    {
                        health -= health;
                    }
                    break;
                case 2:
                    {
                        health -= fullHP/2;
                    }
                    break;
                case 3:
                    {
                        health -= fullHP / 3;
                    }
                    break;
            }
        }
    }

    public void DestoryShip()
    {
        Destroy(gameObject);
        destroyedByPlayer = true;
    }

    private void OnDestroy()
    {
        GameObject ex = (GameObject)Instantiate(explosion);
        ex.transform.position = transform.position;
        ex.transform.rotation = transform.rotation;
        Destroy(ex, 2);

        if(destroyedByPlayer == true)
            WaveSpawner.killStreak++;
    }

}

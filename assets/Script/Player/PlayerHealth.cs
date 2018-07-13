using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{

    #region CLASS_VARIAVLES

    //public
    public Slider slider;
    public GameObject explosion;
    public int health = 100;
    public GameObject gameOverGUI;
    public Text score;
    public Text best;

	#endregion

    void Start()
    {
        gameOverGUI.gameObject.SetActive(false);
    }

	void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Enemy" || c.tag == "EnemyBullet")
        {
            if(health > 0)
            {
                health -= 10;
                slider.value -= 10;
            }

            if (health <= 0)
                Die();

        }
    }

    void Die()
    {

        PlayerPrefs.SetInt("CURRENT_SCORE", WaveSpawner.killStreak);

        if(PlayerPrefs.GetInt("BEST") < WaveSpawner.killStreak)
        {
            PlayerPrefs.SetInt("BEST", WaveSpawner.killStreak);
        }

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("PlayerBullet");
        foreach(GameObject b in bullets)
        {
            Destroy(b);
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject e in enemies)
        {
            Destroy(e);
        }

        GameObject ex = (GameObject)Instantiate(explosion);
        ex.transform.position = transform.position;
        ex.transform.rotation = transform.rotation;

        Destroy(gameObject);
        Destroy(ex, 2);

        score.text = "SCORE: " + PlayerPrefs.GetInt("CURRENT_SCORE").ToString();
        best.text = "BEST: " + PlayerPrefs.GetInt("BEST").ToString();

        gameOverGUI.gameObject.SetActive(true);
    }

}

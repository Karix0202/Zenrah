using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour 
{

    #region CLASS_VARIAVLES

    //publics
    public float timeToExplode;
    public GameObject explosion;

    //privates
    private List<GameObject> enemies = new List<GameObject>();

	#endregion

	void Start () 
	{
        StartCoroutine(CountingToExplode(timeToExplode));
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Enemy")
            enemies.Add(c.gameObject);
    }

    IEnumerator CountingToExplode(float time)
    {
        yield return new WaitForSeconds(time);
        Explode();
    }

    void Explode()
    {
        foreach(GameObject e in enemies)
        {
            if (e != null)
            {
                Destroy(e);
            }             
        }

        GameObject ex = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
        Destroy(ex, 3);
        Destroy(gameObject);
    }

}

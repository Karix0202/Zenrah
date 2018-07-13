using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarGenerator : MonoBehaviour 
{

    #region CLASS_VARIAVLES

    //public
    public GameObject star;
    public int maxStars;

    //private
    private Color[] starColors = {
        new Color(0.5f, 0.5f, 1f), //pink
		new Color(0f, 1f, 1f), //blue
		new Color(1f ,1f, 0f), //yellow
		new Color(1f, 0f, 0f), //red
		new Color(0f, 255f, 8f), //green
		new Color(255f, 102f, 0f), //orange
		new Color(255f, 0f, 255f) //purple
	};

    #endregion

    void Start () 
	{
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


        for (int i = 0; i < maxStars; ++i)
        {
            GameObject s = (GameObject)Instantiate(star);

            s.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            s.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            s.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

            s.transform.parent = transform;
        }
    }

}

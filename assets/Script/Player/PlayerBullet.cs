using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBullet : MonoBehaviour 
{

    #region CLASS_VARIAVLES

    //public
    public float speed = 8f;

	#endregion
	
	void Update () 
	{
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

}

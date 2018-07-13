using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet1 : MonoBehaviour 
{

    #region CLASS_VARIAVLES

    //public
    public float speed;

    //private
    private Vector2 _direction;
    private bool isReady;

    #endregion

    void Awake()
    {
        isReady = false;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }

    void Update()
    {

        if (isReady)
        {

            Vector2 position = transform.position;

            position += _direction * speed * Time.deltaTime;

            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.y < min.y) || (transform.position.x > max.x) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}

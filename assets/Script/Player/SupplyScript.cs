using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyScript : MonoBehaviour
{
    private int quantity;

    public float turnSpeed;
    public float moveSpeed;
	
	private void Start ()
    {
        quantity = UnityEngine.Random.Range(1, 2);
	}

    private void Update()
    {
        Move(moveSpeed);
        Rotate(turnSpeed);
    }

    private void Rotate(float turnSpeed)
    {
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;

        z -= turnSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);

        transform.rotation = rot;
    }

    private void Move(float moveSpeed)
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - moveSpeed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            PlayerGun player = c.GetComponent<PlayerGun>();
            player.bombCount += quantity;
            Destroy(gameObject);
        }
    }
}

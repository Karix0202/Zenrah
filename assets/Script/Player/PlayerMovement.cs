using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour 
{

    #region CLASS_VARIAVLES

    //publics
    public float speed;
    public GameObject crossPlatformInput;
    public bool isEmulator;

    //privates
    private bool isMobile;
    private Vector2 dir;
    private float x;
    private float y;
    private string playerMoving;

    #endregion

    private void Start()
    {
        speed = 11f;
        Debug.Log(speed);
    }

    void Update () 
	{
        isMobile = DeviceController.isMobile;
        if (isMobile == false)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
        }

        if(isMobile == true)
        {
            playerMoving = PlayerPrefs.GetString("PLAYER_MOVING");

            switch (playerMoving)
            {
                case "ACCELERATION":
                    {
                        crossPlatformInput.SetActive(false);
                        x = Input.acceleration.x;
                        y = Input.acceleration.y;
                    }
                    break;

                case "JOYSTICK":
                    {
                        crossPlatformInput.SetActive(true);
                        x = CrossPlatformInputManager.GetAxisRaw("Horizontal");
                        y = CrossPlatformInputManager.GetAxisRaw("Vertical");
                    }
                    break;
            }
        }

        dir = new Vector2(x, y).normalized;
        Move(dir, speed);
    }

    void Move(Vector2 dir, float s)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;

        pos += dir * s * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

}

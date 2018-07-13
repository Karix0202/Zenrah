using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGun : MonoBehaviour 
{

    #region CLASS_VARIAVLES

    //publics
    public float coolDown = 0.40f;
    public GameObject shootPoint1;
    public GameObject shootPoint2;
    public GameObject bullet;
    public AudioSource shootAudio;
    public GameObject bomb;
    public GameObject player;
    public Text bombsCountText;
    public GameObject bombButton;
    public int bombCount = 5;

    //privates
    private bool isMobile;
    private float coolDownTimer;

    #endregion
	
	void Update () 
	{
        isMobile = DeviceController.isMobile;

        

        if(Input.GetButton("Fire1"))
        {
            if (coolDownTimer > 0)
                coolDownTimer -= Time.deltaTime;

            if (coolDownTimer < 0)
                coolDownTimer = 0;

            if (coolDownTimer == 0)
            {
                Shoot();
                shootAudio.Play();
                coolDownTimer = coolDown;
            }
        }
      
        if(isMobile == false)
        {
            bombButton.SetActive(false);
            if (bombCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                    CreateBomb();
            }
        }
        else
        {
            bombButton.SetActive(true);
        }

        bombsCountText.text = "Bombs: " + bombCount.ToString();

    }

    void Shoot()
    {
        GameObject bullet1 = (GameObject)Instantiate(bullet);
        bullet1.transform.position = shootPoint1.transform.position;

        GameObject bullet2 = (GameObject)Instantiate(bullet);
        bullet2.transform.position = shootPoint2.transform.position;
    }

    void CreateBomb()
    {
        bombCount--;
        GameObject b = (GameObject)Instantiate(bomb);
        b.transform.position = transform.position;
        b.transform.rotation = transform.rotation;
    }

    public void BombButtonAction()
    {
        if(bombCount > 0)
        {
            CreateBomb();
        }
    }

}

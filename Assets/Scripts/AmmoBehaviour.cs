using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehaviour : MonoBehaviour
{

    [SerializeField]
    public int ammoClip;
    public int clipSize;
    public int ammoMax;
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    private float reloadTime;
    private bool stopReload;

    public int ammoPickUpSmall = 10;
    public int ammoPickUpBig = 25;


    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnPoint = transform.GetChild(0).gameObject;
    }


    // Update is called once per frame
    void Update()
    {

        if (reloadTime <= 0)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && ammoMax >= 0 && ammoClip != 0)
            {
                ammoClip--;
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation); // Spawns the bullet prefab from the end of gun barrel and shoots it
            }

            if(ammoMax <= 0)
            {
                stopReload = true;
                ammoMax = 0;
            }
            else
            {
                stopReload = false;
            }

            if (Input.GetKeyDown("r") && stopReload == false)  // This reloads the gun if there is spare ammo available
            {
                ammoMax = ammoMax - clipSize;
                ammoClip = clipSize;
                reloadTime = 2;
                Debug.Log("Noice I just reloaded");
            }
        }
        reloadTime -= Time.deltaTime; // This Stops the reload delay allowing the player to shoot again.

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ammoBig"))
        {
            ammoMax = ammoMax + ammoPickUpBig;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("ammoSmall"))
        {
            ammoMax = ammoMax + ammoPickUpSmall;
            Destroy(other.gameObject);
        }
    }

}

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
    private bool reloadBool;
    private bool stopReload;
    private bool canFire;
    private bool crtnActive;
    private float coolDownTime = 0.1f;

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



            if (Input.GetKey(KeyCode.Mouse0) && ammoClip != 0)
            {
                if (canFire)
                {
                    ammoClip--;
                    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation); // Spawns the bullet prefab from the end of gun barrel and shoots it
                    canFire = false;
                }

                if(canFire == false)
                {
                    if(!crtnActive)
                    {
                        StartCoroutine(coolDown());

                    }
                }

            }
            if(ammoMax <= 0)      // Stops ammo count going into negative 
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
                reloadTime = 2;
                reloadBool = true;
            }
        }



        reloadTime -= Time.deltaTime; // This Stops the reload delay allowing the player to shoot again.

        if (reloadTime <= 0 && reloadBool == true)
        {
            int tempValue = ammoMax;
            ammoMax = ammoMax - clipSize + ammoClip;
            ammoClip = clipSize;
            Debug.Log("Noice I just reloaded");
            reloadBool = false;

            if (tempValue < 10)
            {
                ammoClip = tempValue;
            }

            else
            {
                ammoClip = clipSize;
            }
        }
    
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ammoBig"))          // When the player collides with an object with this tag, it provides ammo to the player and is destroyed
        {
            ammoMax += ammoPickUpBig;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("ammoSmall"))       // When the player collides with an object with this tag, it provides ammo to the player and is destroyed
        {
            ammoMax += ammoPickUpSmall;
            Destroy(other.gameObject);
        }
    }

    IEnumerator coolDown()                         // When this function is  called it starts the weapon cool down and resets the canFire to true allowing the player to shoot again
    {
        crtnActive = true;
        yield return new WaitForSeconds(coolDownTime);
        canFire = true;
        crtnActive = false;

    }
}

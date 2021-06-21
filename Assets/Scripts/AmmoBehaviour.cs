using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehaviour : MonoBehaviour
{

    [SerializeField]
    private int ammoClip;
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
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
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

            if (Input.GetKeyDown("r") && stopReload == false)
            {
                ammoMax = ammoMax - clipSize;
                ammoClip = clipSize;
                reloadTime = 2;
                //Debug.Log("Yay i just reloaded");
            }
        }
        reloadTime -= Time.deltaTime; 

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject ammoPickUpBig;
    public float timeBetweenSpawns = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBigAmmo", 1.0f, timeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBigAmmo()
	{
        Instantiate(ammoPickUpBig, transform.position, Quaternion.identity);
    }
}

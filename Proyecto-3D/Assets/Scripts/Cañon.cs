using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour {

    public Transform gun;
    public GameObject playerBullet;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(playerBullet, gun.Find("Cannon2").position, transform.rotation);
        }
    }
}

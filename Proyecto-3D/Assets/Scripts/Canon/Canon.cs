using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

    public Transform gun;
    public GameObject playerBullet;
    public string number;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.K)){
            Instantiate(playerBullet, gun.Find(number).position, transform.rotation);
        }
	}
}

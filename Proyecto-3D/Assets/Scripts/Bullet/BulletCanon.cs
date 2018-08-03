using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCanon : MonoBehaviour {

    public float speed = 3;
    public float lifeSpan = 2;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barco2 : MonoBehaviour {

    public float movementSpeed;
    public float angularSpeed;
    Vector3 movement;
    Quaternion rotation;
    public Rigidbody rigidbody3D;

    void FixedUpdate()
    {
        movement = transform.position;
        rotation = rigidbody3D.rotation;

        float verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.B))
        {
            rotation *= Quaternion.Euler(Vector3.up * -angularSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.M))
        {
            rotation *= Quaternion.Euler(Vector3.up * angularSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement += (-transform.forward) * movementSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement += (transform.forward) * movementSpeed * Time.fixedDeltaTime;
        }
        rigidbody3D.MovePosition(movement);
        rigidbody3D.MoveRotation(rotation);
    }
}

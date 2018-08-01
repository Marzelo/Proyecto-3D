using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminante : MonoBehaviour {

    public float movementSpeed;
    public float angularSpeed;
    Vector3 movement;
    Quaternion rotation;
    public Rigidbody rigidbody3D;

    void FixedUpdate(){
        movement = transform.position;
        rotation = rigidbody3D.rotation;

        float verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Q)){
            rotation *= Quaternion.Euler(Vector3.up * -angularSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.E)){
            rotation *= Quaternion.Euler(Vector3.up * angularSpeed * Time.fixedDeltaTime);
        }
        if (verticalMovement != 0){
            movement += transform.forward * movementSpeed * verticalMovement * Time.fixedDeltaTime;
        }
        rigidbody3D.MovePosition(movement);
        rigidbody3D.MoveRotation(rotation);
    }
}

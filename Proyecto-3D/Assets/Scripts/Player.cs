using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementSpeed;
    public float angularSpeed;
    Vector3 movement;
    Quaternion rotation;
    public Rigidbody rigidbody3D;
    public float salto;

    bool grounded;
    List<Collider> groundedCollection;
 
    void Start(){
        groundedCollection = new List<Collider>();
    }

    void FixedUpdate(){
        movement = transform.position;
        rotation = rigidbody3D.rotation;
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Q)){
            rotation *= Quaternion.Euler(Vector3.up * -angularSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.E)){
            rotation *= Quaternion.Euler(Vector3.up * angularSpeed * Time.fixedDeltaTime);
        }
        if (horizontalMovement != 0){
            movement += transform.right * movementSpeed * horizontalMovement * Time.fixedDeltaTime;
        }
        if (verticalMovement != 0){
            movement += transform.forward * movementSpeed * verticalMovement * Time.fixedDeltaTime;
        }
        rigidbody3D.MovePosition(movement);
        rigidbody3D.MoveRotation(rotation);
    }

    void Update(){
         if (Input.GetKeyDown(KeyCode.Space) && grounded){
            rigidbody3D.AddForce(Vector3.up * salto, ForceMode.Impulse);
         }
    }

    void OnCollisionStay(Collision collision){
         if (!groundedCollection.Contains(collision.collider)) {
            foreach (ContactPoint contact in collision.contacts){
                if (Vector3.Dot(contact.normal, Vector3.up) > 0.75f){
                    grounded = true;
                    groundedCollection.Add(collision.collider);
                    break;
                }
            }
        }
    }

    void OnCollisionExit(Collision collision){
        if (groundedCollection.Contains(collision.collider)){
            groundedCollection.Remove(collision.collider);
        }
        if (groundedCollection.Count <= 0){
            grounded = false;
        }
    }
}

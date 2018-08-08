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

    public PlayerHP playerHP;

    public Transform gun;
    public GameObject playerBullet;

    bool grounded;
    List<Collider> groundedCollection;
 
    void Start(){
        groundedCollection = new List<Collider>();
    }

    void FixedUpdate(){
        movement = transform.position;
        rotation = rigidbody3D.rotation;

        if (Input.GetKey(KeyCode.Q)){
            rotation *= Quaternion.Euler(Vector3.up * -angularSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.E)){
            rotation *= Quaternion.Euler(Vector3.up * angularSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A)){
            movement += (-transform.right) * movementSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.D)){
            movement += (transform.right) * movementSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += (-transform.forward) * movementSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement += (transform.forward) * movementSpeed * Time.fixedDeltaTime;
        }
        rigidbody3D.MovePosition(movement);
        rigidbody3D.MoveRotation(rotation);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.X) && grounded){
            rigidbody3D.AddForce(Vector3.up * salto, ForceMode.Impulse);
            //playerHP.ModifyHP(-2);
         }
        if (Input.GetKeyDown(KeyCode.F)){
            Instantiate(playerBullet, gun.Find("Cannon").position, transform.rotation);
        }
        if (playerHP.currentHP <= 0){
            Destroy(gameObject);
        }
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.transform.CompareTag("Bullet"))
        {
            playerHP.ModifyHP(-2);
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

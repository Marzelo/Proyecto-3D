using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour{

    public float moveSpeed;
    public Vector3 targetDistance;
    public Transform target;
    Vector3 targetNode;

    // Use this for initialization
    void Start(){

    }

    // Update is called once per frame
    void LateUpdate(){
        targetNode = target.position + (target.right * targetDistance.x) + (target.up * targetDistance.y) + (target.forward * targetDistance.z);
        transform.position = Vector3.MoveTowards(transform.position, targetNode, moveSpeed * Time.deltaTime);
        transform.LookAt(target);
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(targetNode, 0.5f);
    }
    
}
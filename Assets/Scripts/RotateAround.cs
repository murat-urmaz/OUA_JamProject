using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform target;     
    public float speed = 50f;   

    public float distanceToPlayer = 2f;

    private Transform orbitingObject;  
    private Vector3 rotateAxis;

    private Vector3 relativePosition;
    private Vector3 direction;
    private Vector3 rotateVelocity;
    private Vector3 lastPosition;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    void Start()
    {

    }

    void Update()
    {
        
        /*
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        orbitingObject.position = target.position;
        orbitingObject.Rotate(new Vector3(0,0,1) * speed * Time.deltaTime);
        */
        
    }

    private void FixedUpdate() {
        transform.RotateAround(target.position, zAxis, speed*Time.deltaTime);
        transform.LookAt(transform.position + target.forward);
    }
    public void biggerPencil()
    {
        transform.localScale = transform.localScale *1.1f;
    }
    public void fasterPencil()
    {
        speed += 25f;
    }
}


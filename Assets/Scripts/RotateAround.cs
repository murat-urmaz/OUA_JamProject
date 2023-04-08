using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform target;     
    public float speed = 50f;   

    private Transform orbitingObject;  

    void Start()
    {
        orbitingObject = transform; 
    }

    void Update()
    {
        
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        orbitingObject.position = target.position;
        orbitingObject.Rotate(new Vector3(0,0,1) * speed * Time.deltaTime);

        
    }
    public void biggerPencil()
    {
        transform.localScale = transform.localScale + new Vector3(0, 1.5f, 0);
    }
    public void fasterPencil()
    {
        speed += 25f;
    }
}


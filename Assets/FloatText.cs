using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatText : MonoBehaviour
{
public float DestroyTime=3f;
public Vector3 Offset = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        //transform.localPosition += Offset;
    }

}

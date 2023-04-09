using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    private Animator letterAnimator;
    // Start is called before the first frame update
    void Start()
    {
        letterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InvokeAnimation(){
        Debug.Log("InvokeCalled");
        letterAnimator.SetTrigger("Click");
    }
}

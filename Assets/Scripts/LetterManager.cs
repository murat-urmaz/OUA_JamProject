using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    private Animator LetterAnimator;
    private Animator TextAnimator;
    public GameObject Clicker;
    public GameObject OpenText;
    public GameObject LetterText;
    // Start is called before the first frame update
    void Start()
    {
        LetterAnimator = GetComponent<Animator>();
        TextAnimator = LetterText.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LetterInvoke(){
        Clicker.SetActive(false);
        OpenText.SetActive(false);
       
        Debug.Log("TriggerCalled");
        LetterAnimator.SetTrigger("Click");
        TextAnimator.SetTrigger("Show");

    }
}

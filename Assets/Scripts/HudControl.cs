using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudControl : MonoBehaviour
{
    private Animator HudAnim;
    // Start is called before the first frame update
    void Start()
    {
        HudAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn(){
        HudAnim.SetTrigger("FadeIn");
    }
}

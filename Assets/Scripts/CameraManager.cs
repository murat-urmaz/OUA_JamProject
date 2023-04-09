using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Animator CamAnimator;
    // Start is called before the first frame update
    void Start()
    {
        CamAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCameras(){
        CamAnimator.SetBool("Cutscene", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSelection : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;
    PlayerController playerController;
  
    void Start()
    {
        pauseManager = GetComponent<PauseManager>();
      
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) //kontrol i�in escyi a��k b�rakt�m daha sonra silece�iz level atlad���nda a��lacak playercontroller i�inde isplayerlevelup adl� bir bool var
        {
            pauseManager.PauseGame();
            panel.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            pauseManager.UnpauseGame();   //ayn� �ekilde test i�in unpause tu�u ekledim bunu daha sonra upgrade se�ildi�inde kapanacak ve oyun devam edecek �eklinde yapaca��z
            panel.SetActive(false);
        }
    }
}

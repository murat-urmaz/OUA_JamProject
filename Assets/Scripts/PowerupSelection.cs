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
        if(Input.GetKeyDown(KeyCode.Escape)) //kontrol için escyi açýk býraktým daha sonra sileceðiz level atladýðýnda açýlacak playercontroller içinde isplayerlevelup adlý bir bool var
        {
            pauseManager.PauseGame();
            panel.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            pauseManager.UnpauseGame();   //ayný þekilde test için unpause tuþu ekledim bunu daha sonra upgrade seçildiðinde kapanacak ve oyun devam edecek þeklinde yapacaðýz
            panel.SetActive(false);
        }
    }
}

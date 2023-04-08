using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupSelection : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;
    public PlayerController playerController;
    RotateAround rotateAround;
    public Button fasterButton;
    public Button biggerPencil;
    public Button fasterPencil;
    public Button fasterBullet;

    private void Awake()
    {
        
        fasterButton.onClick.AddListener(() => 
        {
            playerController.fasterCharacter();
            pauseManager.UnpauseGame();
            panel.SetActive(false);


        });
       
        fasterBullet.onClick.AddListener(() =>
        {
            playerController.incSpeed();
            pauseManager.UnpauseGame();
            panel.SetActive(false);


        });
        rotateAround = FindObjectOfType<RotateAround>();
        biggerPencil.onClick.AddListener(() =>
        {
            rotateAround.biggerPencil();
            pauseManager.UnpauseGame();
            panel.SetActive(false);


        });
        rotateAround = FindObjectOfType<RotateAround>();
        fasterPencil.onClick.AddListener(() =>
        {
            rotateAround.fasterPencil();
            pauseManager.UnpauseGame();
            panel.SetActive(false);


        });
    }
    void Start()
    {
        pauseManager = GetComponent<PauseManager>();
        playerController.OnLevelUp += PlayerController_OnLevelUp;
       
      
    }

    private void PlayerController_OnLevelUp()
    {
        showPowerupMenu();
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.T))
        {
               
            
        }
    }
    void showPowerupMenu()
    {
        pauseManager.PauseGame();
        panel.SetActive(true);
    }
}

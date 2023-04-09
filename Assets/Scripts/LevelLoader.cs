using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

   private PauseManager PauseManagerRef;
   private void Start() {
      PauseManagerRef = GetComponent<PauseManager>();
   }
   public void LoadLevel(string levelName){
      PauseManagerRef.UnpauseGame();
        SceneManager.LoadScene(levelName);
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{  public  Camera cams;
    bool gameHasEnded = false;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public  void KillPlayer()
   {
  if(gameHasEnded==false)
  {
      gameHasEnded = true;
    
   Invoke("CameraFall", 2f);
      

      Invoke("Restart", 3f);
  }
    

   }
   void Restart()
   {
    SceneManager.LoadScene("SampleScene");

   }
   void CameraFall()
   {
Vector3 pos1 = cams.transform.position  + new Vector3(0, -0.4f, 0);
     cams.transform.position = pos1;
      

   }
}

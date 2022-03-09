using UnityEngine;
using System.Collections;
 
 public class billboard : MonoBehaviour {
     
      Animator anim;
      void Awake()
      {
          anim  =GetComponent<Animator>();
      }
     void OnEnable() {
         CameraPreRender.onPreCull += MyPreCull;
     }
 
     void OnDisable() {
         CameraPreRender.onPreCull -= MyPreCull;
     }
    void Update()
    {
        
    }
     void MyPreCull() {
        
         Vector3 difference = Camera.current.transform.position - transform.position;
         difference.y = 0;
         transform.LookAt(transform.position - difference, Camera.current.transform.up);

         var dir = Camera.current.transform.position - transform.position;
          var enemyAngle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
          print(enemyAngle);
          if (enemyAngle < 0.0f){
              enemyAngle += 360;
              }
          
          
          // you can mess about with this last lines. You can add more angles, chnage them, etc.
          if (enemyAngle >= 315f || enemyAngle < 45f)
          {
          anim.Play("Forward");

          }
              
          else if (enemyAngle >= 45f && enemyAngle < 135f){anim.Play("Right");}
              
          else if (enemyAngle >= 135f && enemyAngle < 225f){anim.Play("Left");}
              
          else if (enemyAngle >= 225f && enemyAngle < 315f){anim.Play("Backward");} 
          
     }
 }
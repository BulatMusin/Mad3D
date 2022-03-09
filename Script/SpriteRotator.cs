using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteRotator : MonoBehaviour
{  private Transform target;
   private  int dist ; 

  public Vector3 zalupa = new Vector3(78.0f,0.0f,0.0f);
   public Camera _mCamera;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Controller>().transform;
       // dist = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void RotationOfSprite()
    {
     Vector3 targetVector = _mCamera.transform.position - transform.position;
     float newYangle = Mathf.Atan2(targetVector.z, targetVector.x) *Mathf.Rad2Deg;
     transform.rotation = Quaternion.Euler(0 , -1 * newYangle , 0);
    }
    void Update()
    
    {   
       // Vector3 relativePos = target.position - transform.position;
        
       //transform.LookAt(target);
      transform.Rotate(0,0,0);

       Vector3 targetVector = this.transform.position - _mCamera.transform.position;
       transform.rotation = Quaternion.LookRotation(targetVector, zalupa);
       if (dist <= 2f)
       {
          
       }
    }
}

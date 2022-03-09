using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GSpriteAnimator : MonoBehaviour {
 
    public GameObject cameraToSee;
    public Transform player;
    public float playerAngle;
    Vector3 direction;
   public bool is8Sided, is4Sided;
    public int locationInt, locationInt2;
    Animator anim;
    public Vector3  LookingVector;

 public float angle;
    void Awake () {
        anim = GetComponent<Animator>();
        cameraToSee = Camera.main.gameObject;
    
    }
   
    void Update () {
       
        direction = player.transform.position -transform.position;
        //Vector3 forward = transform.TransformDirection(Vector3.forward);
        //direction = player.transform.position - transform.position;
        
Vector3 targetPosition = new Vector3(cameraToSee.transform.position.x,transform.position.y,cameraToSee.transform.position.z);
       
        transform.LookAt(targetPosition);
        
    
   




       // Debug.Log(angle);

        //GigaChadSprite(angle);
       
      
            Vector3 toPlayer = player.position - transform.position;

           
       UltraGiga19cm();
        
        
        playerAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
        /*
        if(is8Sided && !is4Sided)
        {
       UltraGiga19cm();
        }
       else
        {
            ChangeSprite();
        }
        */
        
        //Vector3 targetPosition = new Vector3(cameraToSee.transform.position.x,transform.position.y,cameraToSee.transform.position.z);
       
        //transform.LookAt(targetPosition);
        locationInt = Mathf.RoundToInt(playerAngle);
        locationInt2 = Mathf.RoundToInt(playerAngle + 45);
    }
 
    public void ChangeSprite() {
        if (locationInt <= 0 && locationInt2 >= 45) anim.Play("Forward");
        else if (locationInt <= 45 && locationInt2 >= 90) anim.Play("Forward");
        else if (locationInt <= 90 && locationInt2 >= 135) anim.Play("Left");
        else if (locationInt <= 135 && locationInt2 >= 180) anim.Play("Backward");
        else if (locationInt <= 180 && locationInt2 >= 225) anim.Play("Backward");
        else if (locationInt <= -135 && locationInt2 >= -135) anim.Play("Backward");
        else if (locationInt <= -90 && locationInt2 >= -90) anim.Play("Right");
        else if (locationInt <= -45 && locationInt2 >= -45) anim.Play("Forward");
    }
    void   UltraGiga19cm()
    {
 if (locationInt <= 0 && locationInt2 >= 45) anim.Play("Forward");
        else if (locationInt <= 45 && locationInt2 >= 90) anim.Play("LForward");
        else if (locationInt <= 90 && locationInt2 >= 135) anim.Play("Left");
        else if (locationInt <= 135 && locationInt2 >= 180) anim.Play("RForward");
        else if (locationInt <= 180 && locationInt2 >= 225) anim.Play("Forward");
        else if (locationInt <= -135 && locationInt2 >= -135) anim.Play("LForward");
        else if (locationInt <= -90 && locationInt2 >= -90) anim.Play("Right");
        else if (locationInt <= -45 && locationInt2 >= -45) anim.Play("Forward");


    }
    
  public void GigaChadSprite(float angle)
  {//Debug.Log(angle);
  if(157.5f <angle && angle <202.5f  )
  anim.Play("Forward");
  
  else if(angle> 202.5f && angle<247.5f)
  anim.Play("RForward");
  else if(angle> 247.5f && angle<292.5f)
  anim.Play("Right");
  else if(angle> 292.5f && angle < 337.5f)
  anim.Play("RBackward");
  else if(angle >337.5f || angle <22.5f)
  anim.Play("Backward");
  else if(angle>22.5f && angle<67.5f)
  anim.Play("LBackward");
  else if(angle>67.5f && angle<112.5f)
  anim.Play("Left");
  else if(angle>112.5f && angle<157.5f)
  anim.Play("LForward");


  }
   


    
}
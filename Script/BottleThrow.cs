using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleThrow : MonoBehaviour
{ 
int damage = 150;
AudioSource source;
public AudioClip breakingSound;
private bool hasCollided = false;


private void Awake()
{
   source = GetComponent<AudioSource>();
     source = GetComponent<AudioSource>();

}

  public  void   OnTriggerEnter(Collider other )
   {
    if(!hasCollided&&other.gameObject.tag == "Enemy")
    {  
      hasCollided = true;
      EnemyHealth enemyHealth= other.GetComponent<EnemyHealth>();
     source.PlayOneShot(breakingSound);
     enemyHealth.BottleHit(damage);
       Invoke("DestroyAss", 0.4f);    
    }
   }
   void DestroyAss()
   
   {
      Destroy(this.gameObject);
   }
  
}
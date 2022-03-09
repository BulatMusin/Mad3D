using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BeerBottle : MonoBehaviour
{
    
  
 
  
 
  public GameObject bottle;
 public GameObject tempParent;
 AudioSource source ;
 public AudioClip drinkingSound;
 
  EnemyHealth enemyHealth;
  PlayerHealth playerHealth;
  public Rigidbody bottleThrow;
  public Transform Player;
Animator anim;
  
 float distance;
 float range = 10f;
 public Transform bottleEnd;
 private bool hasPicked = false;
public int bottleHealth= 50;




void Update()
{if(distance<=range)
{
  
  //anim.SetBool("Drinking", true);
}

}
void Awake()
{
distance= Vector3.Distance(transform.position , Player.position);
  source = GetComponent<AudioSource>();
  anim =GetComponent<Animator>();
}
public void OnTriggerEnter(Collider other)
{   if(other.gameObject.CompareTag("Player"))
{if(!hasPicked)
{hasPicked  =true;
source.PlayOneShot(drinkingSound);
  
    PlayerHealth playerHealth= other.GetComponent<PlayerHealth>();
    playerHealth.BottleHealth(bottleHealth);
Rigidbody projectileInstance;
       projectileInstance= Instantiate(bottleThrow , bottleEnd.position , bottleEnd.rotation) as Rigidbody;
   projectileInstance.AddForce(bottleEnd.forward * 1000f);

   Invoke("DestroyGameObject", 0.4f);
}
}
}

void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
 
 }
      

    


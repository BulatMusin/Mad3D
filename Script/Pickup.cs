using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isHova, isHealth, isGArmor , isAmmo, isBArmor;
    public int amount;
    AudioSource source;
    public AudioClip hovaBong;
    private void Awake ()
    {
      source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("Player"))
    {
       if(isHealth)
      {
        other.GetComponent<PlayerHealth>().AddHealth(amount,this.gameObject);
     
      }
      if(isBArmor)
      {
        other.GetComponent<PlayerHealth>().AddArmor(amount,this.gameObject);
        
       }
        if(isGArmor)
      {
        other.GetComponent<PlayerHealth>().AddArmor(amount,this.gameObject);
        
       }

      if(isAmmo)
      {
        other.GetComponent<Sawed>().AddAmmo(amount,this.gameObject);
        
     }
     if(isHova)
     {
     
     
     other.GetComponent<PlayerHealth>().HovaBonus(amount , this.gameObject);
     }
      
    }

   }
  
}

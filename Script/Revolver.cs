using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Revolver : MonoBehaviour
{  public Sprite gunStatic;
   public Sprite gunShot;
   public float revolverDamage = 45f;
   public float revolverRange ;
   public AudioClip shotSound;
   AudioSource source;
   void Awake()
   {
    source = GetComponent<AudioSource>();

   }
   void FixedUpdate()
   {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;
       if(Input.GetButtonDown("Fire1"))
       {
           source.PlayOneShot(shotSound);
           StartCoroutine("shot");
           if(Physics.Raycast(ray,out hit , revolverRange))
           {
               Debug.Log("TY popal v " + hit.collider.gameObject.name);
           }
       }
   }
   IEnumerator shot()
   {
  GetComponent<SpriteRenderer>().sprite = gunShot;
   yield return new  WaitForSeconds(0.1f);
   GetComponent<SpriteRenderer>().sprite = gunStatic;
   }
}

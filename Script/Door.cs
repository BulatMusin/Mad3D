using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnim;
  private float range = 15.0f;
  private AudioSource source;
    private Transform t;
    private Transform Player;
    public AudioClip stoneDoor;
    private bool isOpen;

    void Awake()
    {
        t= this.transform;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
       

   source = GetComponent<AudioSource>();

    }
    void Start()
    {
        
    }
     private float Distance()
     {
         return Vector3.Distance(t.position, Player.position);
     }

    void Update()
    {  
     if(Distance()<= range && Input.GetKeyDown("e")&& !isOpen)
     {isOpen = true;
     doorAnim.SetTrigger("OpenDoor"); 
     source.PlayOneShot(stoneDoor);
     }
    }

}

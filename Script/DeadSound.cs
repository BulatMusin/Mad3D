using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSound : MonoBehaviour
{  AudioSource source;
Animator anim;
public AudioClip deadBoxer;
    // Start is called before the first frame update
    void Start()
    {   //anim.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        source.PlayOneShot(deadBoxer);
        //anim.Play("Death");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

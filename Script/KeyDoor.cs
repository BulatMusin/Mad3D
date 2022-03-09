using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
     Animator doorAnim;
    AudioSource source;
    public AudioClip doorSound;    
    public bool requiresKey;
    public bool reqRed, reqBlue, reqGreen;
  bool isOpen = true;
   public GameObject KeyText;
void Awake()
{
  doorAnim = GetComponent<Animator>();
  source = GetComponent<AudioSource>();

}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (requiresKey)
            {
                //do additional checks
                if(reqRed && other.GetComponent<PlayerInventory>().hasRed)
                {
                    //opens Door
                    doorAnim.SetTrigger("OpenDoor");
                    
                }

                if (reqBlue && other.GetComponent<PlayerInventory>().hasBlue &&isOpen)
                {  isOpen = false;
                KeyText.SetActive(false);
                    //opens Door
                    doorAnim.Play("openAnim");
                    source.PlayOneShot(doorSound);

                    
                }

                if (reqGreen && other.GetComponent<PlayerInventory>().hasGreen)
                {
                    //opens Door
                    doorAnim.SetTrigger("OpenDoor");
                  
                }
            }
            else
            {
                //opens Door
                doorAnim.SetTrigger("OpenDoor");
               
            }
        }
    }
}
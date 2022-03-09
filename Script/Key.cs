using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public bool isRedKey, isBlueKey, isGreenKey;
  AudioSource source;
  public AudioClip hova;
  void Awake()
  {
     source= GetComponent<AudioSource>();
  }

    void OnTriggerEnter(Collider other)
    {   source.PlayOneShot(hova);
        if (other.CompareTag("Player"))
        {
            if (isRedKey)
            {
                other.GetComponent<PlayerInventory>().hasRed = true;
                CanvasManager.Instance.UpdateKeys("red");
            }

            if (isBlueKey)
            {   
                other.GetComponent<PlayerInventory>().hasBlue = true;
                CanvasManager.Instance.UpdateKeys("blue");
                
                
            }

            if (isGreenKey)
            {
                other.GetComponent<PlayerInventory>().hasGreen = true;
                CanvasManager.Instance.UpdateKeys("green");
            }

           Invoke("DestroyBussy", 0.4f);
        }
    }
void DestroyBussy()
{
    Destroy(gameObject);
}
}
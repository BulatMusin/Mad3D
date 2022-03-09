using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTexter : MonoBehaviour
{  public GameObject KeyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider collider)
    {if(collider.tag == "Player")
     KeyText.gameObject.SetActive(true);
    }

    void OnTriggerExit(Collider collider)
    {
KeyText.gameObject.SetActive(false);
    }
}

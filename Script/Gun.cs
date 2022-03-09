 using System.Collections.Generic;
using UnityEngine;

public  class Gun : MonoBehaviour
{   
    [SerializeField] private int damageAmount;
    public  int range = 100;
    
    public float fireRate = .25f;
    public Camera fpsCam ;
    

    RaycastHit hit;
   

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
   {
       Shoot();
   }
        
    }
    public void Shoot ()
    {  RaycastHit hit;
     
     if(Physics.Raycast (fpsCam.transform.position , fpsCam.transform.forward , out hit, range))
     {
       EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
         
     if(enemyHealth != null)
     {
         enemyHealth.TakeDamage(damageAmount);
     }
     }
        

   
    
     }
   

    }


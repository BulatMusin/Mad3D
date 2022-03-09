
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CanvasManager : MonoBehaviour
{  
   
   
   public int pick;
   public Image zalupon;
   

  

   public TextMeshProUGUI health;
   public TextMeshProUGUI ammo;
   public TextMeshProUGUI armor;
    
   public GameObject redKey;
   public GameObject blueKey;
   public GameObject greenKey;
   
   
   

   
   private static CanvasManager _instance;
   public static CanvasManager Instance 
  
   {
       get {return _instance;}
   }
   private void Awake()
   {   
       if(_instance!= null &&_instance!=this )
       {
           Destroy(this.gameObject);
       }
       else
       {
           _instance =this;
       }
   }

   
   public void Updatehealth(int healthValue )
   {    
       health.text= healthValue.ToString() + "%";
       UpdateHealthIndicator(healthValue );
       if(healthValue< 0)
       {
        healthValue = 0;
        
       }
   }
    public void Updateammo(int ammoValue)
   {
  ammo.text = ammoValue.ToString();
   }
    public void Updatearmor(int armorValue)
   {
       armor.text = armorValue.ToString()+ "%";

   }
  
  
public void UpdateHealthIndicator(int healthValue )
{  
   // timer -= Time.deltaTime;
if(healthValue >= 80)
{          
   

            
}
if(healthValue <80 && healthValue>=60)
{
    
          
            
}
if(healthValue < 60 && healthValue >=40)
{
 
  
           
            
            
    
}
if(healthValue<40 && healthValue >=20)
{   
  
   
   
           

}
if(healthValue<20 && healthValue >0)
{   
   
   
                
   

}

if(healthValue<=0 )
{
   
}

}
   
public void UpdateKeys(string keyColor)
{
if(keyColor== "red")
{
    redKey.SetActive(true);

}
if(keyColor== "blue")
{
    blueKey.SetActive(true);

}
if(keyColor== "green")
{
    greenKey.SetActive(true);

}
}
public void ClearKeys()
{
    blueKey.SetActive(false);
    redKey.SetActive(false);
    greenKey.SetActive(false);
}

}

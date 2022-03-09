using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    private int HovaHealth= 100;
    private int HovaArmor= 100;

private int maxHealth= 100;

private int maxArmor=0;
public int penis;
public int armor;
public int health;
public AudioClip hit;
public AudioClip hovaBong, hovaBong2;
GameObject pickup;
public FlashScreen flash;
public bool isDamaged;
public bool isDead= false;
AudioSource source;
public bool isHova = false;
public bool farted;
bool isGameOver = false;
 void Start()
 {
     armor =0;
     
    health = maxHealth;
     
     source = GetComponent<AudioSource>();
     CanvasManager.Instance.Updatehealth( health );


 }
 void Update()
 {
    //armor = Mathf.Clamp(armor,0,maxArmor);

    //health= Mathf.Clamp(health, 0,maxHealth); 
    if(health<= 0 && !isGameOver )
    {   isGameOver = true;
        GameManager.Instance.PlayerDeath();
    }
    /*
     if(Input.GetKeyDown(KeyCode.R))
    { 
        health-=21;
        CanvasManager.Instance.Updatehealth( health );
    }
    */
    
     if(health<0 || armor < 0)
         {
             health= 0;
             armor =0;
             CanvasManager.Instance.Updatehealth(health );
             CanvasManager.Instance.Updatearmor(armor);
         }
         if(health<= 0)
         {
             
             isDead = true;
         }
         if(isHova)
         {
            maxHealth+=HovaHealth;

         }
 }
 public void BottleHealth(int value)
 {
     health+= value;
     if(health>maxHealth )
     {
         health= maxHealth;
     }
     CanvasManager.Instance.Updatehealth(health );
 }
 public void AddHealth(int value , GameObject pickup)
 {
  health+= value;
  if(health > maxHealth)
  {
      health = maxHealth;
  }
     Destroy(pickup);
CanvasManager.Instance.Updatehealth(health );
 }
 public void AddArmor(int value , GameObject pickup )
 {   
     armor += value;
     if(armor > maxArmor)
  {
      armor = maxArmor;
  }
     Destroy(pickup);
  CanvasManager.Instance.Updatearmor(armor);
 }
 public void HovaBonus( int value , GameObject pickup)
 { isHova = true;
     source.PlayOneShot(hovaBong);
     source.PlayOneShot(hovaBong2);
      if(health>=200)
 {
     health = 200;
 }
 health+= HovaHealth;
     armor += HovaArmor;
     
 //CanvasManager.Instance.Updatearmor(armor);
  CanvasManager.Instance.Updatehealth(health );
   Destroy(pickup);
 }
 
public void EnemyHit(int damage)

{  if(health>0)
{
    penis = damage;
    Invoke(nameof(InflictDamage), 0.7f);
  
        
    source.PlayOneShot(hit);
   
    flash.TookDamage();
    //CanvasManager.Instance.Updatehealth(health);
    CanvasManager.Instance.Updatearmor(armor);
    if(!farted)
{
    farted =true;
    source.PlayOneShot(hit);
Invoke(nameof(ResetFart), 0.0f);
}
}
}
public  void ResetFart()
{
farted = false;
}
public void InflictDamage()
{   if(health>=0)
{
health-= penis;
    CanvasManager.Instance.Updatehealth(health );
}
    
}
public void ColliderMessage()
{
    
    
}

}
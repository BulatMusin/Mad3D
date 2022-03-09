using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sawed : MonoBehaviour
{
    public Sprite gunStatic;
   public Sprite gunShot;
   
   public Sprite reload1;
   public Sprite reload2;
   public Sprite reload3;
   public Sprite reload4;
   public Sprite drinkBottle;
   public float sawedDamage = 45f;
   public float sawedRange ;
   public AudioClip shotSound;
   public AudioClip reloadSound;
   public AudioClip emptySound;
   public Text ammoText;
   public int ammoAmount ;
   public int ammoClipSize;
   int ammoLeft;
   int ammoClipLeft;
   AudioSource source;
    bool isShot;
    bool isReloading;
    public GameObject bulletHole;
    GameObject crosshair;
    public GameObject pickup;
  public void Start()
  {
      
  }
   void Awake()
   {
    source = GetComponent<AudioSource>();
  ammoLeft = ammoAmount;
  ammoClipLeft = ammoClipSize; 
   }
   void Update()
   {    //ammoText.text = ammoClipLeft + "/" + ammoLeft;
         if(Input.GetButtonDown("Fire1") && isReloading == false)
         isShot = true;
         if(Input.GetKeyDown(KeyCode.R)&& isReloading == false && ammoClipLeft!=ammoClipSize)
         {
             Reload();
         }
    
   }
   private void OnEnable()
   {
       isReloading =false;
   //crosshair = GameObject.Find("Crosshair");
   //crosshair.SetActive(false);
   }
   //private void OnDisable()
  // {
   //    crosshair.SetActive(false);
  // }
   void FixedUpdate()
   {    Vector2 bulletOffset = Random.insideUnitCircle;
        Vector3 randomTarget = new Vector3(Screen.width/2 + bulletOffset.x , Screen.height/2+ bulletOffset.y,0);
       Ray ray = Camera.main.ScreenPointToRay(randomTarget);
       RaycastHit hit;
       if(isShot==true && ammoClipLeft > 0 && isReloading == false)
       {   isShot = false;
           ammoClipLeft--;
           source.PlayOneShot(shotSound);
           StartCoroutine("shot");
           if(Physics.Raycast(ray,out hit , sawedRange))
           {   if(hit.transform.CompareTag("Enemy"))
           {
               if(hit.collider.gameObject.GetComponent<EnemyStates>().currentState==hit.collider.gameObject.GetComponent<EnemyStates>().patrolState ||hit.collider.gameObject.GetComponent<EnemyStates>().currentState==hit.collider.gameObject.GetComponent<EnemyStates>().alertState  )
           {
                hit.collider.gameObject.SendMessage("HiddenShot",transform.parent.transform.position, SendMessageOptions.DontRequireReceiver);
           }
               
              // Debug.Log("TY popal v " + hit.collider.gameObject.name);
               hit.collider.gameObject.SendMessage("sawedHit", sawedDamage, SendMessageOptions.DontRequireReceiver);
           }
           else
              {
                
                Instantiate(bulletHole,hit.point,Quaternion.FromToRotation(Vector3.up,hit.normal)).transform.parent = hit.collider.transform;
              //GameObject shit = Instantiate(bulletHole , hit.point , Quaternion.LookRotation(hit.normal));

            
            
           }
          
           }
       }
       else if(isShot==true && ammoClipLeft <=0 && isReloading == false)
       {
           isShot=false;
           Reload();
       }
       
   }
   void Reload()
   {
       int bulletsToReload =ammoClipSize - ammoClipLeft;
       if(ammoLeft >= bulletsToReload)
       {   StartCoroutine("ReloadWeapon");
      
           ammoLeft -= bulletsToReload;
           ammoClipLeft = ammoClipSize;
       }
       else if (ammoLeft < bulletsToReload && ammoLeft >0)
       {StartCoroutine("ReloadWeapon");
        ammoClipLeft += ammoLeft;
        ammoLeft = 0;
       }
       else if(ammoLeft <=0)
       {
           source.PlayOneShot(emptySound);
       }
   }
  
   IEnumerator ReloadWeapon()

   { 
       isReloading = true;
       source.PlayOneShot(reloadSound);
       
       yield return new WaitForSeconds(2);
       isReloading = false;
   }
   IEnumerator shot()
   {
  GetComponent<SpriteRenderer>().sprite = gunShot;
   

   yield return new  WaitForSeconds(0.7f);

   GetComponent<SpriteRenderer>().sprite = gunStatic;
   }
  public void DrinkBottle()
  {StartCoroutine("EatShit");
     

  }
  IEnumerator EatShit()
  {
      GetComponent<SpriteRenderer>().sprite = drinkBottle;
  yield return new  WaitForSeconds(0.7f);
  }
public void AddAmmo(int value , GameObject pickup)
{
    ammoLeft += value;
       Destroy(pickup);
}

}

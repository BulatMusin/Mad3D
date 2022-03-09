using UnityEngine;
using System.Collections;
using TMPro;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    
    Animator animator;
     
   private Transform t;
    private Transform Player;
    public int damage;
   
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    public float kickingRange = 10.0f;
    public int kickingDamage = 100;

    //bools 
    bool shooting, readyToShoot, reloading;
    AudioSource source;
    public AudioClip shotSound , reloadSound , emptySound;
    public Sprite gunShot , gunStatic , gunReload;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    EnemyHealth enemyHealth;
     
   
    public AudioClip kickingSound;
    public float sphereRadius;
     bool shootCoro, reloadCoro, legCoro;
     bool isReloading = true;
    
bool isShooting= true;
    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    //public CamShake camShake;
    public float camShakeMagnitude, camShakeDuration;
   // public TextMeshProUGUI text;
   private void Start()
   {
       shootCoro = true;
       legCoro =true;
       reloadCoro = true;
   }
    private void Awake()
    {  
        t= GameObject.FindGameObjectWithTag("Player").transform;
        Player = GameObject.FindGameObjectWithTag("Enemy").transform;
        source = GetComponent<AudioSource>();
    animator = GetComponent<Animator>();
    

        bulletsLeft = magazineSize;
        readyToShoot = true;
         CanvasManager.Instance.Updateammo(bulletsLeft);
    }
    public void Update()
    {CanvasManager.Instance.Updateammo(bulletsLeft);
        MyInput();
     if(Input.GetKeyDown("q")&& legCoro)
     {  legCoro = false;
     StartCoroutine(LegCoroutine());
         animator.Play("LegKick");
         source.PlayOneShot(kickingSound);
      LegKick();
         

     }
     

  if(shootCoro)
  {
if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0) && isShooting&& shootCoro &&!isReloading)
 {  shootCoro = false;
 isShooting = false;
 isReloading  =true;
 reloading = false; 
 animator.Play("ShotColt");
 StartCoroutine(ShootCoroutine());
 

    
 }
  }  
  
    if(Input.GetKeyDown(KeyCode.R) && bulletsLeft <6 && reloadCoro && isReloading)
    { reloadCoro = false;
   isReloading  =false;
animator.Play("ReloadColt");
source.PlayOneShot(reloadSound);
StartCoroutine(ReloadCoroutine());



        

    }

    if(readyToShoot && !reloading && !shooting )
    {
animator.SetBool("Idling", true);

    }
    else
    {
        animator.SetBool("Idling", false);
    }
       
    
  
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
            bulletsShot = bulletsPerTap;
            Shoot();
            
        }
    }
    private float Distance()
     {
         return Vector3.Distance(t.position, Player.position);
     }
    public void Shoot()
    {    
    source.PlayOneShot(shotSound);
   
   
            readyToShoot = false;
        GetComponent<SpriteRenderer>().sprite = gunShot;
       

   GetComponent<SpriteRenderer>().sprite = gunStatic;
        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        //ShakeCamera
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    IEnumerator LegCoroutine()
    {  yield return new WaitForSeconds(1.2f);
        legCoro = true;
    }
    private void Reload()
    {  
   
    
    
    Invoke(("ReloadOne"), 0f);
   

   
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
        if(bulletsLeft <=0)
       {
           source.PlayOneShot(emptySound);
       }
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
 IEnumerator ShootCoroutine()
 {  
     yield return new WaitForSeconds(1f);
     isShooting = true;
     shootCoro = true;
    
     animator.Play("IdleColt");
 }
 IEnumerator ReloadCoroutine()
 {   yield return new WaitForSeconds(1.5f);
    
      reloadCoro =true;
      isReloading =true;
     

 

 }
    
   void LegKick()
   {   
   
Vector3 direction = fpsCam.transform.forward;
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, 15, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<EnemyHealth>().TakeDamage(100);
        }
   
        
   }
    
    }

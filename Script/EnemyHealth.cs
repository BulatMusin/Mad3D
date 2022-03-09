using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   public int enemyHealth;
    public int maxenemyHealth;
   private bool wasHit = false;
   
    AudioSource source;
    public AudioClip enemyGrunt; 
    public GameObject myPrefab;
    public AudioClip deathSound;
     public Animation anim;
     public Animator animator;
    public bool isDead = false;
    public SpriteRenderer sr;
    public Sprite painSprite;
    public Enemy enemy;
     DynamicBillboardChange dynamicBillboardChange;
  
    // Start is called before the first frame update
   public  void Update ()
    {
    if(isDead)
    {
        animator.Play("Death");
    }
    }
    private void Start()
    {    animator = GetComponent<Animator>();
          anim = GetComponent<Animation>();
          source = GetComponent<AudioSource>();
    }
    void Awake()
    {
        enemyHealth=maxenemyHealth;
        isDead = false;
        
    }
  public void BottleHit(int damageAmount)
   {
   enemy.GetComponent<Enemy>().ChaseState();
   source.PlayOneShot(enemyGrunt);
enemyHealth-=damageAmount;
  if(enemyHealth<=0)
        {isDead =true;
         //dynamicBillboardChange.DeathAnim(isDead);
         
        animator.Play("Death");
        animator.Play("Forward", -1, 0f);
        Die();
        }

   }
    public void TakeDamage(int damageAmount)
    {  
        
        enemyHealth-=damageAmount;
        source.PlayOneShot(enemyGrunt);
        PainState();
        if(enemyHealth<=0)
        { isDead = true;
            animator.Play("Death");
        animator.Play("Backward", -1, 0f);
        //animator.SetBool("Dying", true);
        Invoke("Die", 0.5f);
        }
        
    }
   void PainState()
   {
   
   }
    void Die()
    {  
        Destroy(gameObject);
        
        SpawnCorpse();
    }
    public void SpawnCorpse()
   {
   Instantiate(myPrefab, transform.position, Quaternion.identity);

   }
  
}

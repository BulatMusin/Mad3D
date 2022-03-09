using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
   public AngleToPlayer angleToPlayer;
    public bool isDead, alreadyAttacked;
    public float timeBetweenAttacks = 1.5f;
    public Transform player;
    public GameObject Player;
    //public int enemyHealth ;
     public LayerMask whatIsGround, whatIsPlayer;
//Sound n' shiet
   private  AudioSource source;
    public AudioClip shotSound;
    public AudioClip AggroSound, BAggroSound;
    public AudioClip EnemyGrunt;
    
    public bool farted, afarted ;
    public int meleeDamage = 15;
    public bool aggroSound , baggroSound;
    public int farDamage = 8;
    public GameObject myPrefab;
   //Timer n shiet
   public float waitTime = 2.0f;
   private float timer = 0.0f;
  public Animator animator;

    public bool isChasing , isAttacking , isDying;
   public bool isMelee;
    public NavMeshAgent agent;
   public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange , stopAttack;
 public GameObject cameraToSee;
 bool canSee= false;
 public GameObject EnemySprite;
    private void Start()
    { 
    
       angleToPlayer = GetComponent<AngleToPlayer>();
    }

    private void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {   
       
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange,whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange,whatIsPlayer);
        if(!playerInSightRange && !playerInAttackRange) IdleState();
        if(playerInSightRange && !playerInAttackRange) ChaseState();
        if(playerInSightRange && playerInAttackRange&& isMelee) AttackState();
        //if(playerInSightRange && playerInAttackRange&& !isMelee) LongAttackState();
       
      
      if(playerInAttackRange)
      {
        animator.Play("Attack_Front");
      }
       
        
    }


public bool Sertificate()
{
    return canSee = true;
}

    private void IdleState()
    {
   timer += Time.deltaTime;
   if(timer > waitTime)
   {
       source.PlayOneShot(EnemyGrunt);
       timer = 0;
   }


    }
    public  void ChaseState()
    { 
    
 agent.SetDestination(player.position);
        if(!aggroSound)
    {
        source.PlayOneShot(AggroSound);
        aggroSound =true;
    

    }
    if(!baggroSound)
    {
        Invoke("BaggroSoundMethod", 6f);
        baggroSound  =true;
    }
   

    
       
    }
    void BaggroSoundMethod()
    {
        source.PlayOneShot(BAggroSound);
        //baggroSound  =true;
        
    }
    public void AttackState()
    {     
       
        
        if(0 <= Player.GetComponent<PlayerHealth>().health )
    {transform.LookAt(player);

if(!alreadyAttacked)
{Player.GetComponent<PlayerHealth>().EnemyHit(meleeDamage);
    alreadyAttacked =true;
    Invoke(nameof(ResetAttack), timeBetweenAttacks);
    if(!afarted)
{ 
    afarted =true;
    source.PlayOneShot(shotSound);
Invoke(nameof(AResetFart), 0.5f);
}
}

    
//agent.SetDestination(transform.position);

}
        
    }
    private void AResetFart()
    { 
        afarted = false;
    }
    private void ResetAttack()
    {
alreadyAttacked = false;
    }
    public void LongAttackState(bool canLongShoot)
    {   if(!isMelee)
    {


         Vector3 lookVector = player.transform.position - transform.position;
         lookVector.y = transform.position.y;
         //Quaternion rot = Quaternion.LookRotation(lookVector);
         //transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        if(0<=Player.GetComponent<PlayerHealth>().health )
        if(!alreadyAttacked)
{   Player.GetComponent<PlayerHealth>().EnemyHit(farDamage);

    alreadyAttacked =true;
    

    Invoke(nameof(ResetAttack), timeBetweenAttacks);
}
if(!farted)
{  animator.SetBool("Attacking", true);
    farted =true;
    source.PlayOneShot(shotSound);
Invoke(nameof(ResetFart), 0.4f);
}


    }
       
  

    }
    public void ResetFart()
    { 
        farted= false;
    }
    private void PainState()
    {

        
    }
    private void DeathState()
    {

        
    }
  
 
}

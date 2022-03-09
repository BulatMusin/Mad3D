using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BottleGulman : MonoBehaviour
{    public bool isDead, alreadyAttacked;
    public float timeBetweenAttacks = 1.5f;
    public Transform player;
    public GameObject Player;
    //public int enemyHealth ;
     public LayerMask whatIsGround, whatIsPlayer;
//Sound n' shiet
   private  AudioSource source;
    public AudioClip shotSound;
    public AudioClip AggroSound;
    public AudioClip EnemyGrunt;
    
    public bool farted, afarted ;
    public int meleeDamage = 15;
    public bool aggroSound ;
    public bool baggroSound;
    public int farDamage = 8;
    public GameObject myPrefab;
   //Timer n shiet
   public float waitTime = 2.0f;
   private float timer = 0.0f;
   Animator animator;

    PlayerHealth playerHealth;
   public bool isMelee;
    public NavMeshAgent agent;
   public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange , stopAttack;    private void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange,whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange,whatIsPlayer);
        if(!playerInSightRange && !playerInAttackRange) IdleState();
        if(playerInSightRange && !playerInAttackRange) ChaseState();
        if(playerInSightRange && playerInAttackRange) LongAttackState();
        
       
      
       
        
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
    private void ChaseState()
    { agent.SetDestination(player.position);
        if(!aggroSound)
    {
        source.PlayOneShot(AggroSound);
        aggroSound =true;
    

    }
    

       
    }

   
    private void ResetAttack()
    {
alreadyAttacked = false;
    }
    private void LongAttackState()
    {    //animator.SetBool("Attacking", true);
    animator.Play("Attack");
         Vector3 lookVector = player.transform.position - transform.position;
         lookVector.y = transform.position.y;
         Quaternion rot = Quaternion.LookRotation(lookVector);
         transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
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
    public void ResetFart()
    { animator.SetBool("Attacking", false);
      animator.SetBool("Forwarding", true);
        farted= false;
    }
    void OnTriggerEnter(Collider other)
    {
        LongAttackState();
    }
    
  
}

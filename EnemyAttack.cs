using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent Nav;
    private NavMeshHit hit;
    private bool blocked = false;
    private bool RunToPlayer = false;
    private float DistanceToPlayer;
    private bool IsChecking = true; // casting to scan player
    private int FailedChecks = 0;
    private bool HitActive = false;
    public int secondsLeft = 10;
    public bool takingAway = false;
    private bool RunAway = false;

    [SerializeField] Animator HurtAnim;
    [SerializeField] Animator Anim;
    [SerializeField] Transform Player;
    [SerializeField] Transform Cave;
    [SerializeField] GameObject Enemy;
    public float MaxRange;
    [SerializeField] int MaxChecks = 3;
    [SerializeField] float ChaseSpeed = 8.5f;
    [SerializeField] float WalkSpeed = 1.6f;
    [SerializeField] float AttackDistance = 2.3f;
    [SerializeField] float AttackRotateSpeed = 2.0f;
    [SerializeField] float CheckTime = 3.0f;

   

    // Start is called before the first frame update
    void Start()
    {
        MaxRange = 20.0f;
        Nav = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {           
        DistanceToPlayer = Vector3.Distance(Player.position, Enemy.transform.position);      

        

        
        if (DistanceToPlayer < MaxRange)
        {
            if (IsChecking == true)
            {
                IsChecking = false;
                blocked = NavMesh.Raycast(transform.position, Player.position, out hit, NavMesh.AllAreas);

                if (blocked == false)
                {
                    Debug.Log("I can see the player");
                    RunToPlayer = true;
                    FailedChecks = 0;
                }
                if (blocked == true)
                {

                    Debug.Log("I Cant see the player");
                    RunToPlayer = false;
                    Anim.SetInteger("State", 1);
                    FailedChecks++;
                    
                }

                StartCoroutine(TimedCheck());
            }   
        }

        if (RunToPlayer == true)
        {
            Enemy.GetComponent<EnemyMove>().enabled = false;
            if (DistanceToPlayer > AttackDistance)
            {
                
                Nav.isStopped = false;
                Anim.SetInteger("State", 2);
                Nav.acceleration = 24;
                Nav.SetDestination(Player.position);
                Nav.speed = ChaseSpeed;
            }
            if (DistanceToPlayer < AttackDistance - 0.5f)
            {      
                Nav.isStopped = true;                    
                Anim.SetInteger("State", 3);
                Nav.acceleration = 130;

                Vector3 Pos = (Player.position = Enemy.transform.position).normalized;
                Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, PosRotation, Time.deltaTime * AttackRotateSpeed);       

                
                     
                if(SaveScript.Apples > 0)
                {                 
                    RunAway = true;
                    SaveScript.Apples -= 1;
                    Anim.SetTrigger("React");
                    RunToPlayer = false;
                    MaxRange = 1.0f;                                          
                    StartCoroutine(Pause());
                }
                if(SaveScript.Apples == 0)
                {
                    SaveScript.PlayerHealth -= 100;
                                  
                }
               

            }           

        }






        
        
    else if (RunToPlayer == false) 
        {
            Nav.isStopped = false;
       
        }
      
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RunToPlayer = true;
        }

    }


    IEnumerator TimedCheck()
    {
        yield return new WaitForSeconds(CheckTime);
        IsChecking = true;

        if (FailedChecks > MaxChecks)
        {
            Enemy.GetComponent<EnemyMove>().enabled = true;
            Nav.isStopped = false;
            Nav.speed = WalkSpeed;
            FailedChecks = 0;   
        }
    }


     IEnumerator Pause()
    {
        Anim.SetTrigger("React");
        yield return new WaitForSeconds(5);
        if(RunAway == true)
        {
           Enemy.GetComponent<EnemyMove>().enabled = true;
            Nav.isStopped = false;
            Nav.speed = 3.0f;
            MaxRange = 20.0f;
        }

        
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        takingAway = false;
        if(secondsLeft == 0)
        {
            MaxRange = 20.0f;
        }
    }

}

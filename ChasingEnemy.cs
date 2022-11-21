using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingEnemy : MonoBehaviour
{
    private NavMeshAgent Nav;
    private NavMeshHit hit;
    private bool blocked = false;
    private bool RunToPlayer = false;
    private float DistanceToPlayer;
    private bool IsChecking = true; // casting to scan player
    private int FailedChecks = 0;
    private bool HitActive = false;
    private bool RunAway = false;

    [SerializeField] Animator HurtAnim;
    [SerializeField] Animator Anim;
    [SerializeField] Transform Player;
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject EnemyAttack;
    public float MaxRange;
    [SerializeField] float WalkSpeed = 1.6f;
    [SerializeField] float AttackDistance = 2.3f;
    [SerializeField] float AttackRotateSpeed = 2.0f;
    [SerializeField] float ChaseSpeed = 8.5f;
   

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
        if (SaveScript.Bat == true)
        {   
            Enemy.GetComponent<EnemyMove>().enabled = false;
            EnemyAttack.GetComponent<EnemyAttack>().enabled = false;     
                      
                Nav.isStopped = false;
                Anim.SetInteger("State", 2);
                Nav.acceleration = 24;
                Nav.SetDestination(Player.position);
                Nav.speed = ChaseSpeed;
            
            
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
                    StartCoroutine(Stop());
                }
                if(SaveScript.Apples == 0)
                {
                    Debug.Log("You dead");
                                  
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


    


    IEnumerator Stop()
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


}

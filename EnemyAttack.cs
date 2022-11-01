using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent Nav;
    private NavMeshAgent Finding;
    private NavMeshHit hit;
    private bool blocked = false;
    private bool RunToPlayer = false;
    private float DistanceToPlayer;
    private bool IsChecking = true; // casting to scan player
    private int FailedChecks = 0;
    public int SecondsLeft = 30;
    public bool takingAway = false;

    [SerializeField] Animator Anim;
    [SerializeField] Transform Player;
    [SerializeField] GameObject Enemy;
    private float MaxRange = 20.0f;
    [SerializeField] int MaxChecks = 3;
    [SerializeField] float ChaseSpeed = 8.5f;
    [SerializeField] float WalkSpeed = 1.6f;
    [SerializeField] float AttackDistance = 2.3f;
    [SerializeField] float AttackRotateSpeed = 2.0f;
    [SerializeField] float CheckTime = 3.0f;
    //[SerializeField] GameObject ChaseMusic;
    [SerializeField] GameObject ScreamSound;


    // Start is called before the first frame update
    void Start()
    {
        //Nav = GetComponentInParent<NavMeshAgent>();
        //ChaseMusic.gameObject.SetActive(false);
        ScreamSound.gameObject.SetActive(false);
    }
    private void Awake()
    {
        Nav = GetComponentInParent<NavMeshAgent>();
    }
   

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false & SecondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }


        DistanceToPlayer = Vector3.Distance(Player.position, Enemy.transform.position);
        if (DistanceToPlayer < MaxRange)
        {
            //Debug.Log(DistanceToPlayer);
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
                    //Nav.destination = MovePosition.position;
                    //Nav.SetDestination(Player.position);
                    Anim.SetInteger("State", 1);
                    FailedChecks++;

                }

                StartCoroutine(TimedCheck());
            }
        }

        else if (SaveScript.Bat == true)
        {           
            RunToPlayer = true;

            if (SecondsLeft == 0)
            {                            
                //Nav.isStopped = false;
                Anim.SetInteger("State", 2);
                ScreamSound.gameObject.SetActive(true);
                Nav.destination = Player.position;
                FailedChecks = 0;

            }
        }
        
           
        if (RunToPlayer == true)
        {
            Enemy.GetComponent<EnemyMove>().enabled = false;
            //ChaseMusic.gameObject.SetActive(true);
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
                Debug.Log("Im attcking");
                Anim.SetInteger("State", 3);
                Nav.acceleration = 180;

                Vector3 Pos = (Player.position = Enemy.transform.position).normalized;
                Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, PosRotation, Time.deltaTime * AttackRotateSpeed);
            }

        }
        else if (RunToPlayer == false) 
        {
            Nav.isStopped = true;
       
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
            //ChaseMusic.gameObject.SetActive(false);
            ScreamSound.gameObject.SetActive(true);


        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        SecondsLeft -= 1;
        takingAway = false;

    }

}

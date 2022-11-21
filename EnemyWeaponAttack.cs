using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponAttack : MonoBehaviour
{
    [SerializeField] Animator HurtAnim;
    [SerializeField] GameObject ScreamSound;
    private bool HitActive = false;
    private UnityEngine.AI.NavMeshAgent Nav;
    private Animator Anim;
    public bool takingAway = false;
    public int secondsLeft = 30;
    private GameObject Agony;
    public GameObject Agony2;


    
     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(HitActive == false)
            {
                Debug.Log("Where r u going");                                                                                                   
                    
            }          
            if(HitActive == true)
            {
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(HitActive == true)
            {
                HitActive = false;
            }
        }


    }
    // Start is called before the first frame update
    void Start()
    {
       Nav = GetComponentInParent<UnityEngine.AI.NavMeshAgent>(); 
       Anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {        
        
    }

    IEnumerator CountDown()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        takingAway = false;
            
    }
}

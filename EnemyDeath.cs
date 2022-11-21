using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeath : MonoBehaviour
{
    
    public GameObject TurnOffMove;
    public GameObject TurnOffAttack;
    private NavMeshAgent Nav;
    
    [SerializeField] GameObject Enemy;
    [SerializeField] Animator Anim;
    [SerializeField] GameObject DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        DeathSound.gameObject.SetActive(false);
        Nav = GetComponentInParent<NavMeshAgent>();

    }

    void Update()
    {
        if(SaveScript.Knife == true && SaveScript.Axe == true)
        {
            DeathSound.gameObject.SetActive(true);
            Anim.SetInteger("State",6);    
            TurnOffMove.SetActive(false);
            TurnOffAttack.SetActive(false);   
            Enemy.GetComponent<EnemyMove>().enabled = false;
            Nav.isStopped = true;
        }       
        
    }



}

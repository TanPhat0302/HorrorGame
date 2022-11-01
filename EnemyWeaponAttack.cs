using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponAttack : MonoBehaviour
{
    [SerializeField] int WeaponDamage = 1;
    [SerializeField] Animator HurtAnim;
    private int EnemyHealth = 10; 
    private bool HitActive = false;
    private UnityEngine.AI.NavMeshAgent Nav;
    private Animator Anim;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(HitActive == false)
            {
                if(SaveScript.Apples > 0 )
                {

                    HitActive = true;
                    SaveScript.Apples -= 1;
                    


                }
                else if(SaveScript.Apples == 0 )
                {
                    HitActive = true;
                    HurtAnim.SetTrigger("Hurt");
                    SaveScript.PlayerHealth -= WeaponDamage;
                    SaveScript.HealthChanged = true;
                }
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
  

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] Text HealthText;
    [SerializeField] GameObject DeathPanel1;
    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = SaveScript.PlayerHealth +"%";
        DeathPanel1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.HealthChanged == true)
        {
            SaveScript.HealthChanged = false;
            HealthText.text = SaveScript.PlayerHealth + "%";
        }

        if(SaveScript.PlayerHealth <= 0f)
        {
            SaveScript.PlayerHealth = 0;
            DeathPanel1.gameObject.SetActive(true);

        }
    }
}

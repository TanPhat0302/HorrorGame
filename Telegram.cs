using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Telegram : MonoBehaviour
{
    [SerializeField]
    private Image Letter;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Letter.enabled = true;

        }
    }

    void OnTrigerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Letter.enabled = false;
        }
    }
  
}

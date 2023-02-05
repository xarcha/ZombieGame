using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectItems : MonoBehaviour
{
    PlayerHealth playerHealth;
    
    void Start()
    {
        playerHealth= GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthItem"))
        {
            playerHealth.AddHealth(0.1f);
            other.gameObject.SetActive(false);
            Debug.Log("Added 0.1 healths "+playerHealth.GetHealth());
        }
    }


    void Update()
    {
        
    }
}

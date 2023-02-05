using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int startHealth;
    private int currentHealth;
    void Start()
    {
        currentHealth = startHealth;
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    public void Hit(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
            // to do : zombiyi öldür
            Debug.Log("Zombie is dead " + currentHealth);
        }
        Debug.Log("Zombie took damage " + currentHealth);

    }

    void Update()
    {
        
    }
}

using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public MovePlayer movePlayer;
    public GameObject GameOverScreen;
    public UnityEngine.UI.Image lifeBar;
    public GameObject Canvas;


    private void Awake()
    {
        movePlayer = GetComponent<MovePlayer>();
    }



    void Start()
    {
        currentHealth = maxHealth;

    }
    public float GetHealth()
    {
        return (float)currentHealth;
    }

    public void DeductHealth(float damage)
    {
        //currentHealth = currentHealth - damage;
        currentHealth -= damage;
        Debug.Log("Player took damage " + currentHealth);
        lifeBar.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            Debug.Log("Player dead");
            movePlayer.speed = 0;
            GameOverScreen.SetActive(true);
        }
    }


    //private void KillPlayer()
    //{

    //    print("Player is dead");
    //}

    public void ResetHealth()
    {
        currentHealth = 1;
    }

    public void AddHealth(float value)
    {
        currentHealth = currentHealth + value;
        lifeBar.fillAmount = (currentHealth/maxHealth)*1;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void Update()
    {

    }

   
}

   

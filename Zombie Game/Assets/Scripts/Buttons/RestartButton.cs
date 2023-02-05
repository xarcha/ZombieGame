using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RestartButton : MonoBehaviour
{
    public Button RestartButtonLocation;
    public GameObject Player;
    public PlayerHealth PlayerHealth;
    public MovePlayer PlayerMovement;
    public Shoot shoot;

    private void Awake()
    {
        PlayerHealth = FindObjectOfType<PlayerHealth>();
        PlayerMovement = FindObjectOfType<MovePlayer>();
        shoot = FindObjectOfType<Shoot>();
    }

    private void OnEnable()
    {
        Player = transform.gameObject;
        RestartButtonLocation.onClick.AddListener(RestartGame);
    }

    public void RestartGame() 
    {
        PlayerHealth.ResetHealth();
        PlayerMovement.BackToTheStartPos();
        shoot.ResetAmmo();
        // Player.transform.position = new Vector3(-8, 1.1f, -10.7f);
        transform.GetComponent<PlayerHealth>().GameOverScreen.SetActive(false);
        
        
        
        
    }
    
}

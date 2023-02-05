using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


enum ZombieState
{
    Idle = 0,
    Walk = 1,
    Attack = 3,
    Dead = 2

}
public class ZombieAI : MonoBehaviour
{
    //Idle
    //Walk
    //Attack
    //Dead
    Animator animator;
    NavMeshAgent agent;
    ZombieState zombieState;
    GameObject playerObject;
    PlayerHealth playerHealth;
    ZombieHealth zombieHealth;
    
    void Start()
    {
        zombieHealth = GetComponent<ZombieHealth>();//bu scripti al demek  
        playerObject = GameObject.FindWithTag("Player");
        playerHealth = playerObject.GetComponent<PlayerHealth>();
        zombieState = ZombieState.Idle;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if (zombieHealth.GetHealth() <=0)
        {
            SetState(ZombieState.Dead);
        }
        switch (zombieState)
        {
            case ZombieState.Dead:
                KillZombie();
                break;
            case ZombieState.Attack:
                Attack();
                break;
            case ZombieState.Walk:
                SearchForTarget();
                break;
            case ZombieState.Idle:
                SearchForTarget();
                break;
            default:
                break;
        }
    }

    private void Attack()
    {
        SetState(ZombieState.Attack);
        agent.isStopped= true;
    }
    void MakeAttack()
    {
        playerHealth.DeductHealth(0.1f);
        SearchForTarget();
    }

    private void SearchForTarget()
    {
        float distance = Vector3.Distance(transform.position, playerObject.transform.position);
        if (distance < 1.75f)
        {
            Attack();
        }
        else if (distance < 15)
        {
            MoveToPlayer();
        }
        else
        {
            SetState(ZombieState.Idle);
            agent.isStopped = true; 
        }
    }

    private void SetState(ZombieState state)
    {
        zombieState = state;
    //Animator
        
        animator.SetInteger("state", (int)state);

    }

    private void MoveToPlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(playerObject.transform.position);
        SetState(ZombieState.Walk);
        
    }

    private void KillZombie()
    {
        SetState(ZombieState.Dead);
        agent.isStopped = true;
        Destroy(gameObject,5);
    }
}

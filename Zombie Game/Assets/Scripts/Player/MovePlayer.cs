using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public int speed = 3;
    const float gravity = 9.8f;
    public CharacterController characterController;

    public Vector3 StartPosition;
    
    
    void Start()
    {
        StartPosition = new Vector3(10, 1, 25);
        transform.position = StartPosition;
        
        characterController= GetComponent<CharacterController>();//unity içinde bulmak için yapýlan kod
    }

    
    void Update()
    {
        MoveCharacter();
    }
    Vector3 moveVector;

    public void MoveCharacter()
    {
        if (speed == 0)
            return;

        moveVector = new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime, 0, Input.GetAxis("Vertical")*speed*Time.deltaTime);
        moveVector = transform.TransformDirection(moveVector);
        if (!characterController.isGrounded)
        {
            moveVector.y -= Time.deltaTime * gravity;
        }
        characterController.SimpleMove(moveVector);    
    }

    public void BackToTheStartPos() 
    {
        characterController.enabled = false;
        transform.position = StartPosition;
        speed = 300;
        characterController.enabled = true;
    }
}

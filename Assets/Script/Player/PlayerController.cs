﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f; // The speed that the Player will move

    Vector3 movement;
    Rigidbody playerRigidbody;
    Animator animator;
    AudioSource audioSource;
    int floorMask; // the layer that player mouse must be on it
    float camRayLength = 100f; 

    // Start is called before the first frame update
    void Start()
    {
        floorMask = LayerMask.GetMask("Floor"); // reference the layer
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        move(h,v);
        anim();
        Turning();

    }

    // Character will move by using horizontal and vertical and mutiply by speed and time and plus character position
    void move(float h, float v){
        movement.Set(h,0f,v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void anim(){
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)){
            animator.SetBool("isWalk",true);
            audioSource.mute = false;

        }else{
            animator.SetBool("isWalk",false);
            audioSource.mute = true;
        }
    }


    // character will turning follow player mouse But player mouse must on a floor layer
    void Turning(){
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit floorHit;

        if(Physics.Raycast (camRay,out floorHit,camRayLength,floorMask)){
            Vector3 playertoMouse = floorHit.point - transform.position;

            playertoMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playertoMouse);

            playerRigidbody.MoveRotation(newRotation);
        }
    }

    
}

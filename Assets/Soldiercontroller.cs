using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiercontroller : MonoBehaviour
{
    float speed = 4f;
    float rotspeed = 80f;
    float rot = 0f;
    float gravity = 8;

    Vector3 MoveDir = Vector3.zero;
    CharacterController controller;
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded){
            if(Input.GetKey(KeyCode.W)){
                MoveDir = new Vector3(0,0,1);
                MoveDir *= speed;
                MoveDir = transform.TransformDirection(MoveDir);
            }
            if(Input.GetKeyUp(KeyCode.W)){
                MoveDir = Vector3.zero;
            }
            
        }

        rot += Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0,rot,0);

        MoveDir.y -= gravity * Time.deltaTime;
        controller.Move(MoveDir * Time.deltaTime);
    }
}

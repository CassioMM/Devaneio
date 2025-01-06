using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float vel = 6;
    public float rotVel = 50;
    public float gravidade = 20;
    public Vector3 moveDir = Vector3.zero;
    public CharacterController control;
    public Animator anim;


    // Update is called once per frame
    void Update()
    {
        if (control.isGrounded)
        {
            moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
            //moveDir = new Vector3(0, 0, Input.GetAxis("Vertical_J"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= vel;
        }

        moveDir.y -= gravidade * Time.deltaTime;
        control.Move (moveDir * Time.deltaTime);


        //Rotation
        float rotacao = Input.GetAxis("Horizontal") * rotVel;
        //float rotacao = Input.GetAxis("Horizontal_J") * rotVel;
        rotacao *= Time.deltaTime;

        transform.Rotate(0, rotacao, 0);

        //Animacion

        if (control.isGrounded)
        {
            if(moveDir.z != 0)
            { 
                anim.SetBool ("Parado", false);
                anim.SetBool ("Andando", true);
            }
            else
            {
                anim.SetBool ("Parado", true);
                anim.SetBool ("Andando", false);
            }


        }


    }
}

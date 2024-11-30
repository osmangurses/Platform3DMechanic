using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public int move_speed;
    public float jump_force;
    public Transform groundCheck;
    public float groundCheckDistance = 0.1f;

    private Rigidbody rb;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h_input = Input.GetAxis("Horizontal");
        float v_input = Input.GetAxis("Vertical");

        GetComponent<Animator>().SetFloat("YatayHiz", h_input);
        GetComponent<Animator>().SetFloat("DikeyHiz", v_input);

        transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X"),0);
        Vector3 moveDirection = transform.TransformDirection(new Vector3(h_input,0,v_input))*move_speed;
        rb.velocity = new Vector3(moveDirection.x,rb.velocity.y,moveDirection.z);

        GroundCheck();

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        }
    }

    void GroundCheck()
    {
        Debug.DrawRay(groundCheck.position, Vector3.down * groundCheckDistance, Color.red);
        if (Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance))
        {
            isGrounded = true;
            GetComponent<Animator>().SetBool("IsGrounded", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsGrounded", isGrounded);
            isGrounded = false;
        }
    }
}

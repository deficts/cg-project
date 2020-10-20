using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            bool isJumping = Input.GetButtonDown("Jump");
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            moveDirection = new Vector3(h, 0, v);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if(h != 0 || v > 0)
            {
                animator.SetBool("forward", true);
            }else if ( v < 0)
            {
                animator.SetBool("backwards", true);
            }
            else
            {
                animator.SetBool("forward", false);
                animator.SetBool("backwards", false);
            }

            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
            }

            animator.SetBool("isJumping", isJumping);           
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
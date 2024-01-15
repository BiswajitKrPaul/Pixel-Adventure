using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private LayerMask groundlayer;

    [SerializeField] private float groundCheckDistance;

    private Rigidbody2D playerRb;

    private bool isGrounded;

    private Animator animator;

    private bool isMoving;




    // Start is called before the first frame update
    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        UpdateAnimation();
    }

    private void FixedUpdate() {

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundlayer);
        MovePlayer();
        JumpPlayer();
    }

    private void JumpPlayer() {
        if (Input.GetKey(KeyCode.Space)) {
            playerRb.velocityY = jumpForce;
        }
    }

    private void MovePlayer() {
        float axis = Input.GetAxisRaw("Horizontal");
        playerRb.velocityX = axis * moveSpeed;

        if (axis != 0)
            isMoving = true;
        else
            isMoving = false;
    }

    private void UpdateAnimation() {
        animator.SetBool("isMoving", isMoving);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
    }
}

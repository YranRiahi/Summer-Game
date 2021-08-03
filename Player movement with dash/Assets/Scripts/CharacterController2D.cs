using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private LayerMask dashLayerMask;
    private const float MOVEMENT_SPEED = 8f;
    private Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
    private bool isDashButtonDown;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if(Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }

        if(Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }

        if(Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if(Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        moveDir = new Vector3(moveX, moveY).normalized;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isDashButtonDown = true;
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = moveDir * MOVEMENT_SPEED;


        if(isDashButtonDown)
        {
            float dashAmount = 5f;

            Vector3 dashPosition = transform.position + moveDir * dashAmount;

            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, moveDir, dashAmount, dashLayerMask);
            
            if(raycastHit2d.collider != null)
            {
                dashPosition = raycastHit2d.point;
            }

            rigidbody2D.MovePosition(dashPosition);
            isDashButtonDown = false;
        }
    }
}

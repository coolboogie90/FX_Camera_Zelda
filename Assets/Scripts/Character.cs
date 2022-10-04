using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    private InputAction moveAction;
    private PlayerInputActions actions;
    public float moveSpeed = 10.0f;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        actions = new PlayerInputActions();
        moveAction = actions.Player.Move;
        moveAction.Enable();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();    //mouvement de type Vector2
        Vector2 movement = moveDirection * moveSpeed * Time.fixedDeltaTime;
        Vector3 translation = new Vector3(movement.x, 0f, movement.y); //le z du movement en 3D = le y du movement en 2D
        rb.MovePosition(transform.position + translation); //la nouvelle position du rigidbody après mouvement
        if(moveDirection != Vector2.zero)
        {
            transform.forward = translation;
        }
    }

    public void Activate(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("Activate Combat Mode!");
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("I like to move it, move it.");
        }
    }
}

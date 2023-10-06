using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private Rigidbody2D _rigidbody;

    public bool switchMovementType;
    [Header("Movement")]

    private float moveSpeed = 5f;
    public float walkSpeed = 5f;
    [Header("Gravity")]
    public float gravitySpeed = 2f;
    public float rigidbodyGravityScale = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move");
        _rigidbody = GetComponent<Rigidbody2D>();

        moveSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (!switchMovementType)
        {
            Movement();
        }
        else 
        {
            GravityMovement();
        }
    }

    private void Movement()
    {
        //set Variables
        moveSpeed = walkSpeed;
        _rigidbody.gravityScale = rigidbodyGravityScale;
        //Player Horizontal Movement
        Vector2 input = _moveAction.ReadValue<Vector2>();
        float horizontalInput = input.x;

        _rigidbody.velocity = new Vector2(horizontalInput * moveSpeed, _rigidbody.velocity.y);
    }

    private void GravityMovement()
    {
        //set Variables
        _rigidbody.gravityScale = 0f;
        moveSpeed = gravitySpeed;
        //Player Floaty Movement
        Vector2 input = _moveAction.ReadValue<Vector2>();
        float horizontalInput = input.x;
        float verticalInput = input.y;

        _rigidbody.AddForce(new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed));
    }
}

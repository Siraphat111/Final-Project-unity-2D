using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerCon playerController;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        playerController = new PlayerCon();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() 
    {
        playerController.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        movement = playerController.Movement.Move.ReadValue<Vector2>();
        {
            myAnimator.SetFloat("moveX", movement.x);
            myAnimator.SetFloat("moveY", movement.y);
        }
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        move();
    }

    private void AdjustPlayerFacingDirection()
    {
        if (Mouse.current == null || Camera.main == null) return;

        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRenderer.flipX = true;
        }
        else 
        {
            mySpriteRenderer.flipX = false;
        }
    }

    private void move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

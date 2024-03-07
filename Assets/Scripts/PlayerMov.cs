using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    #region Vars
    private PlayerInputActions playerInputActions;
    private Rigidbody2D rb;

    private Vector2 normalHeight;

    private float jumpForce = 7.5f;
    private GameObject groundCheck;
    private bool isGrounded;
    private bool isCrouching;
    #endregion

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        playerInputActions.Enable();
        playerInputActions.Move.Jump.performed += Jump;
        playerInputActions.Move.Crouch.performed += Crouch;
        normalHeight = transform.localScale;
        groundCheck = transform.GetChild(1).gameObject;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded && !isCrouching)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void Crouch(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0 && isGrounded)
        {
            transform.localScale = new Vector2(transform.localScale.x, 1);
            isCrouching = true;
        }
        else
        {
            transform.localScale = normalHeight;
            isCrouching = false;
        }
    }

    public void HitBySomeSh()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}

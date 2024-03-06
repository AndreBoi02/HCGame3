using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isCrouching;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        playerInputActions.Enable();
        playerInputActions.Move.Jump.performed += Jump;
        playerInputActions.Move.Crouch.performed += Crouch;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded && !isCrouching) // Solo permite saltar si el jugador est� en el suelo y no est� agachado
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void Crouch(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0) // El jugador est� agach�ndose
        {
            GetComponent<SpriteRenderer>().size = new Vector2(GetComponent<SpriteRenderer>().size.x, 1);
            GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, 1);
            isCrouching = true;
        }
        else // El jugador deja de agacharse
        {
            GetComponent<SpriteRenderer>().size = new Vector2(GetComponent<SpriteRenderer>().size.x, 2);
            GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, 2);
            isCrouching = false;
        }
    }

    // Aseg�rate de actualizar la variable isGrounded en alg�n lugar de tu c�digo
    // Por ejemplo, podr�as hacerlo en OnCollisionEnter2D y OnCollisionExit2D
}

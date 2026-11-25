using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{
    public Vector2 moveInput { get; private set; }
    public Vector2 attackInput { get; private set; }
    
    private Inputs _inputs;

    private void Awake()
    {
        _inputs = new Inputs();

        _inputs.Player.Movement.performed += OnMove;
        _inputs.Player.Movement.canceled += OnMove;

        _inputs.Player.Attack.performed += OnAttack;
        _inputs.Player.Attack.canceled += OnAttack;
    }

    void OnEnable() => _inputs.Player.Enable();
    void OnDisable() => _inputs.Player.Disable();

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
        
    }

    private void OnAttack(InputAction.CallbackContext ctx)
    {
        attackInput = ctx.ReadValue<Vector2>();
    }

}

using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterControl _input;
    private Rigidbody2D _rb;


    void Start()
    {
        _input = GetComponent<CharacterControl>();
        _rb = GetComponent<Rigidbody2D>();
    }

    

    public void MovePlayer(float moveSpeed)
    {
        _rb.linearVelocity = _input.moveInput * (moveSpeed * Time.deltaTime);
    }

}

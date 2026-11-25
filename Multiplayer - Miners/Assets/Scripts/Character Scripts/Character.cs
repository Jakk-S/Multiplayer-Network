using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterStats _stats;
    private CharacterControl _control;
    private CharacterMovement _movement;
    private CharacterCamera _camera;

    
    
    void Awake()
    {
        _stats = GetComponent<CharacterStats>();
        _control = GetComponent<CharacterControl>();
        _movement = GetComponent<CharacterMovement>();
        _camera = GetComponent<CharacterCamera>();
    }

    void Start()
    {
        
        
    }
    
    
    void FixedUpdate()
    {
        _movement.MovePlayer(_stats.speed);
        
    }
}

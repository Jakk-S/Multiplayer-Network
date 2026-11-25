using UnityEngine;
using System.Collections;
public class MeleeAttack : MonoBehaviour
{
    private CharacterControl _control;

    [SerializeField] private GameObject attackBox;
    private PolygonCollider2D _collider;
    private SpriteRenderer _sprRenderer;

    [SerializeField] private float attackSpeed = 0.4f;
    private bool _attacking = false;
    
    
    
    void Awake()
    {
        _control  = GetComponentInParent<CharacterControl>();
        
        if (attackBox == null) return;
        _collider = attackBox.GetComponent<PolygonCollider2D>();
        _sprRenderer = attackBox.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        SetSpriteAlpha(0f);
        _collider.enabled = false;
    }

    void FixedUpdate()
    {
        if (!_control.attackInput.Equals(Vector2.zero) && !_attacking)
        {
            StartCoroutine(AttackRoutine(_control.attackInput));
        }
        
        if(!_attacking)
        {
            if (_sprRenderer.color.a != 0f)
            {
                SetSpriteAlpha(0f);
            }
        }
        
    }

    void SetSpriteAlpha(float alpha)
    {
        Color _col = _sprRenderer.color;
        _col.a = alpha;
        _sprRenderer.color = _col;
    }

    IEnumerator AttackRoutine(Vector2 direction)
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        
        _attacking = true;
        _collider.enabled = true;
        SetSpriteAlpha(1f);
        
        yield return new WaitForSeconds(attackSpeed);
        
        _collider.enabled = false;
        SetSpriteAlpha(0f);
        _attacking = false;
    }

    void OnDrawGizmos()
    {
        if (_collider == null) return;
        _collider = attackBox.GetComponent<PolygonCollider2D>();
        Gizmos.color = Color.red;

        
        Vector2[] points = _collider.GetPath(0);

        for (int i = 0; i < points.Length; i++)
        {
            Vector2 a = points[i];
            Vector2 b = points[(i + 1) % points.Length];
                
            Vector3 worldA = transform.TransformPoint(a);
            Vector3 worldB = transform.TransformPoint(b);

            Gizmos.DrawLine(worldA, worldB);
        }
        
    }
}

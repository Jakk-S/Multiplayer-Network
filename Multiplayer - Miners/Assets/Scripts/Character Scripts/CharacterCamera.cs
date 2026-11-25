using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    private CharacterControl _input;
    private Camera _camera;

    void Awake()
    {
        _input = GetComponent<CharacterControl>();
        _camera = Camera.main;
    }
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        MoveCamera();

    }

    void MoveCamera()
    { 
        Vector3 camPos = _camera.transform.position;
        Vector2 targetCamPos = transform.position;
        
        Vector3 newPos = Vector2.Lerp(camPos, targetCamPos, cameraSpeed * Time.deltaTime);

        _camera.transform.position = new Vector3(newPos.x, newPos.y, camPos.z);
    }
}

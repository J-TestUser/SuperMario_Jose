using UnityEngine;
using UnityEngine.InputSystem;

public class Platform : MonoBehaviour

{
    private BoxCollider2D _boxCollider2D;

    private InputAction _moveAction;

    private Vector2 _moveInput;

    [SerializeField]private bool isOnPlatform;

    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _moveAction = InputSystem.actions["Move"];


    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();

        Debug.Log(_moveInput);

        if (_moveInput.y < 0 && isOnPlatform)
        {
            _boxCollider2D.isTrigger = true;
            isOnPlatform = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isOnPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isOnPlatform = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            _boxCollider2D.isTrigger = false;
        }
    }
}

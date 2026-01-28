using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector3 startPosition;
    public float movementSpeed = 5f;

    public float jumpForce = 1;
    public float bounceForce= 3;
    private AudioSource _audioSource;
    private BoxCollider2D _boxCollider;

    public AudioClip jump;
    public AudioClip deathSFX;

    private InputAction moveAction;
    public Vector2 moveDirection;
    private InputAction jumpAction;

    public Rigidbody2D rBody2D;
    private SpriteRenderer renderer;
    private GroundSensor sensor;
    private Animator animator;
    private BGMManager _bgmManager;

    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>(); //Asignamos el componente RigidBody2D a la variable rBody2D
        renderer = GetComponent<SpriteRenderer>();
        sensor = GetComponentInChildren<GroundSensor>(); //GetComponentInChildren busca un componente de entre los hijos del objeto que tiene este script
        animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();

        _bgmManager = GameObject.Find("BGM Manager").GetComponent<BGMManager>();

        moveAction = InputSystem.actions["Move"]; //Asignamos el input move a la variable
        jumpAction = InputSystem.actions["Jump"]; //Asignamos el input Jump  a la variable
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       transform.position = startPosition;
       
    }

    // Update is called once per frame
    void Update()
    {
        rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y);
        //transform.position = new Vector3(transform.position.x + direction * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        //transform.Translate(new Vector3(direction * movementSpeed *Time.deltaTime, 0, 0));

        //transform.position = Vector2.MoveTowards(transform.position, finalPosition + new Vector3(10,0,0), movementSpeed *Time.deltaTime);

        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + direction, transform.position.y), movementSpeed * Time.deltaTime);

        moveDirection = moveAction.ReadValue<Vector2>();

        //transform.position = new Vector3(transform.position.x + moveDirection.x *movementSpeed *Time.deltaTime, transform.position.y, transform.position.z);

        //transform.Translate(new Vector3(moveDirection.x *movementSpeed*Time.deltaTime,0,0));

        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + moveDirection.x, transform.position.y), movementSpeed * Time.deltaTime);
        if(moveDirection.x > 0)
        {
            renderer.flipX = false;
            animator.SetBool("IsRunning", true);
        }
        else if(moveDirection.x < 0)
        {
            renderer.flipX = true;
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
       

        if(jumpAction.WasPressedThisFrame() && sensor.isGrounded)
        {
            rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _audioSource.PlayOneShot(jump);
            
        }
        animator.SetBool("IsJumping", !sensor.isGrounded);

    }
    public void Bounce()
    {
        rBody2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }

    public void MarioDeath()
    {        
        movementSpeed = 0;

        _audioSource.PlayOneShot(deathSFX);
        
        _boxCollider.enabled = false;

        animator.SetTrigger("IsDead");
        
        _bgmManager.StopBGM();

        Destroy (gameObject,3);


    }
}

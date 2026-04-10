using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Vector3 startPosition;
    public float movementSpeed = 5f;

    public float jumpForce = 1;
    public float bounceForce= 5;
    private AudioSource _audioSource;
    private BoxCollider2D _boxCollider;

    public AudioClip jump;
    public AudioClip deathSFX;

    private InputAction moveAction;
    public Vector2 moveDirection;
    private InputAction jumpAction;
    private InputAction pauseAction;
    private InputAction shootAction;

    public Rigidbody2D rBody2D;
    private SpriteRenderer renderer;
    private GroundSensor sensor;
    private Animator animator;
    private BGMManager _bgmManager;
    private GameManager _gameManager;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public GameObject attackHitbox;

    private bool _canShoot = false;
    private float _powerUpDuration = 10;
    private float _powerUpTimer;

    public ParticleSystem _walkParticles;
    //private Coin _coin;

    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>(); //Asignamos el componente RigidBody2D a la variable rBody2D
        renderer = GetComponent<SpriteRenderer>();
        sensor = GetComponentInChildren<GroundSensor>(); //GetComponentInChildren busca un componente de entre los hijos del objeto que tiene este script
        animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        //_walkParticles = GetComponentInChildren<ParticleSystem>();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _bgmManager = GameObject.Find("BGM Manager").GetComponent<BGMManager>();
        //_coin = GameObject.Find("Coin").GetComponent<Coin>();

        moveAction = InputSystem.actions["Move"]; //Asignamos el input move a la variable
        jumpAction = InputSystem.actions["Jump"]; //Asignamos el input Jump  a la variable
        pauseAction = InputSystem.actions["Pause"];
        shootAction = InputSystem.actions["Attack"];
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       transform.position = startPosition;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseAction.WasPressedThisFrame())
        {
            _gameManager.Pause();
        }

        if (_gameManager._pause == true)//Si pausamos el juego, todo lo que hay debajo de esta linea de codigo deja de ejecutarse
        {
            return;
        }

         moveDirection = moveAction.ReadValue<Vector2>();
         
         //le asignamos a la variable moveDirection el valor que nos de la variable moveaction en formtao vector2

        //transform.position = new Vector3(transform.position.x + direction * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        //transform.Translate(new Vector3(direction * movementSpeed *Time.deltaTime, 0, 0));

        //transform.position = Vector2.MoveTowards(transform.position, finalPosition + new Vector3(10,0,0), movementSpeed *Time.deltaTime);

        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + direction, transform.position.y), movementSpeed * Time.deltaTime);

        //transform.position = new Vector3(transform.position.x + moveDirection.x *movementSpeed *Time.deltaTime, transform.position.y, transform.position.z);

        //transform.Translate(new Vector3(moveDirection.x *movementSpeed*Time.deltaTime,0,0));

        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + moveDirection.x, transform.position.y), movementSpeed * Time.deltaTime);
        if(moveDirection.x > 0)
        {
            //renderer.flipX = false;
            transform.rotation = Quaternion.Euler(0,0,0);
            animator.SetBool("IsRunning", true);
            if(!_walkParticles.isPlaying && sensor.isGrounded)
            {
                _walkParticles.Play();
            }

        }
        else if(moveDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
            animator.SetBool("IsRunning", true);
            _walkParticles.Play();
            if(!_walkParticles.isPlaying && sensor.isGrounded)
            {
                _walkParticles.Play();
            }
        }
        else
        {
            animator.SetBool("IsRunning", false);

            if(_walkParticles.isPlaying && sensor.isGrounded)
            {
                _walkParticles.Stop();
            }
        }
       

        if(jumpAction.WasPressedThisFrame() && sensor.isGrounded)
        {
            rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _audioSource.PlayOneShot(jump);
            _walkParticles.Stop();
            
        }
        animator.SetBool("IsJumping", !sensor.isGrounded);

        if (shootAction.WasPressedThisFrame() && _canShoot)
        {
            Shoot();
            //Attack();
            //animator.SetTrigger("Attack");
        }
        
        if(_canShoot)
        {
            ShootPowerUp();
        }


    }
    void FixedUpdate()
    {
        rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y);
    }

    public void Bounce()
    {
        rBody2D.linearVelocity = new Vector2(rBody2D.linearVelocity.x, 0);
        rBody2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }

    public void MarioDeath()
    {        
        movementSpeed = 0;

        _audioSource.PlayOneShot(deathSFX);
        
        _boxCollider.enabled = false;

        animator.SetTrigger("IsDead");
        
        _bgmManager.StopBGM();

        StartCoroutine(_gameManager.GameOver());

        Destroy (gameObject,3.2f);

    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Coin _coin = collision.gameObject.GetComponent<Coin>();
            _coin.GetCoin();
        }
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            _powerUpTimer = 0;
            _canShoot = true;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    void ShootPowerUp()
    {
        _powerUpTimer += Time.deltaTime;

        if(_powerUpTimer >= _powerUpDuration)
        {
            _canShoot = false;
        }
    }

    void Attack()
    {
        if (attackHitbox.activeInHierarchy)
        {
            attackHitbox.SetActive(false);
        }
        else
        {
            attackHitbox.SetActive(true);
        }
    }

}

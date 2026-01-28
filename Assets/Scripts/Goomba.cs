using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;

    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;

    public AudioClip deadSFX;

    public float movementSpeed = 4;
    public int direction = 1;
    private Animator animator;

    private GameManager _gameManager;

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _rigidBody2D.linearVelocity = new Vector2(direction * movementSpeed, _rigidBody2D.linearVelocity.y);
        animator.SetBool("Is Walking", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tuberias") || collision.gameObject.layer == 7)
        {
            //Esto hacec lo mismo que la linea de abajo pero de forma mas intuitiva
            //direction = direction * -1;
            direction *= -1;
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
    public void DeadGoomba()
    {
        _audioSource.PlayOneShot(deadSFX);
        
        movementSpeed = 0;

        _boxCollider.enabled = false;

        animator.SetTrigger("Is Dead");

        Destroy (gameObject,3);
        _gameManager.AddKill();
    }
}

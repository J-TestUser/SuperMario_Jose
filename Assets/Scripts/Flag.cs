using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;

    public AudioClip flagSound;
    private BGMManager _bgmManager;
    private GameManager _gameManager;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _bgmManager = GameObject.Find("BGM Manager").GetComponent<BGMManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
        _audioSource.PlayOneShot(flagSound);
        _bgmManager.StopBGM();
        _boxCollider.enabled = false;
        
        }   
        StartCoroutine(_gameManager.Victory());
    }
}
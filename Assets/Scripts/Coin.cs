using UnityEngine;

public class Coin : MonoBehaviour

{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    public AudioClip coinSounds;
    private SpriteRenderer coinRenderer;

    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        coinRenderer = GetComponent<SpriteRenderer>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void GetCoin()
    {
        _audioSource.PlayOneShot(coinSounds);

        _boxCollider.enabled = false;

        coinRenderer.enabled = false;

        Destroy (gameObject, 1);
        
        _gameManager.AddCoin();
    }

}

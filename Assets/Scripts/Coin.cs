using UnityEngine;

public class Coin : MonoBehaviour

{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;

    public AudioClip coinSounds;

    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        coinSounds = GetComponent<AudioClip>();   

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetCoin()
    {
        _audioSource.PlayOneShot(coinSounds);

        _boxCollider.enabled = false;

        Destroy (gameObject,0.2f);
        
        _gameManager.AddCoin();
    }

}

using UnityEngine;

public class Coin : MonoBehaviour

{
    public BoxCollider2D _boxCollider;
    public AudioSource _audioSource;

    public AudioClip coinSounds;

    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        coinSounds = GetComponent<AudioClip>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetCoin()
    {
        _audioSource.PlayOneShot(coinSounds);

        _boxCollider.enabled = false;

        Destroy (gameObject);
        
        _gameManager.AddCoin();
    }

}

using UnityEngine;

public class Flag : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;

    public AudioClip flagSound;
    private BGMManager _bgmManager;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();

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
    }
}
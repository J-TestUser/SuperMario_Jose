using UnityEngine;

public class GroundSensor : MonoBehaviour
{
 public bool isGrounded;
 PlayerController _playerController;
 public BoxCollider2D[] _deathZone;
 public int jumpDamage = 3;
 public ParticleSystem _landingParticle;

void Awake()
{
    _playerController = GetComponentInParent<PlayerController>();
    _deathZone = GameObject.Find("DeathZones").GetComponentsInChildren<BoxCollider2D>();
    //_landingParticle = GetComponentInChildren<ParticleSystem>();
}
 void OnTriggerEnter2D (Collider2D collision)
 {
    if(collision.gameObject.layer == 6)
    {
        isGrounded = true;
        _landingParticle.Play();
    }
    if(collision.gameObject.layer == 7)
    {
        _playerController.Bounce();

        Goomba _enemyScript = collision.gameObject.GetComponent<Goomba>();
        _enemyScript.TakeDamage(jumpDamage, Vector3.zero, 0);

        //Destroy(collision.gameObject);
    }
    if(collision.gameObject.CompareTag("DeathZone"))
    {
        _playerController.Bounce();
        _playerController.MarioDeath();
        foreach (BoxCollider2D item in _deathZone)
        {
          item.enabled = false;  
        }
    }
   /* if(collision.gameObject.CompareTag("Player"))
    {
        
    }*/
 }
void OnTriggerStay2D (Collider2D collision)
 {
    if(collision.gameObject.layer == 6)
    {
        isGrounded = true;
    }
 }
void OnTriggerExit2D (Collider2D collision)
 {
    if(collision.gameObject.layer == 6)
    {
        isGrounded = false;
    }
 }
 
}

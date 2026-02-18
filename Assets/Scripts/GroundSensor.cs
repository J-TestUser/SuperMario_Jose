using UnityEngine;

public class GroundSensor : MonoBehaviour
{
 public bool isGrounded;
 PlayerController _playerController;
 public BoxCollider2D[] _deathZone;

void Awake()
{
    _playerController = GetComponentInParent<PlayerController>();
    _deathZone = GameObject.Find("DeathZones").GetComponentsInChildren<BoxCollider2D>();
}
 void OnTriggerEnter2D (Collider2D collision)
 {
    if(collision.gameObject.layer == 6)
    {
        isGrounded = true;
    }
    if(collision.gameObject.layer == 7)
    {
        _playerController.Bounce();

        Goomba _enemyScript = collision.gameObject.GetComponent<Goomba>();
        _enemyScript.TakeDamage();

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

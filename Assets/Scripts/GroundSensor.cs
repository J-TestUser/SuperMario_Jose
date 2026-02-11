using UnityEngine;

public class GroundSensor : MonoBehaviour
{
 public bool isGrounded;
 PlayerController _playerController;

void Awake()
{
    _playerController = GetComponentInParent<PlayerController>();
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

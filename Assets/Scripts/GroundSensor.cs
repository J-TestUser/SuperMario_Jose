using UnityEngine;

public class GroundSensor : MonoBehaviour
{
 public bool isGrounded;
 PlayerController _playerController;

void Awake()
{
    _playerController = GetComponent<PlayerController>();
}
 void OnTriggerEnter2D (Collider2D collision)
 {
    if(collision.gameObject.layer == 6)
    {
        isGrounded = true;
    }
    if(collision.gameObject.layer == 7)
    {
        Goomba _enemyScript = collision.gameObject.GetComponent<Goomba>();
        _enemyScript.DeadGoomba();
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

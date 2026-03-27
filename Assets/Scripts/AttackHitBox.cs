using UnityEngine;

public class AttackHitBox : MonoBehaviour
{

    public int attackDamage = 3;
    public float attackImpactForce = 15;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer ==7)
        {
            Goomba _enemyScript = collision.gameObject.GetComponent<Goomba>();
            _enemyScript.TakeDamage(attackDamage, transform.right, attackImpactForce);
        }
    }

}

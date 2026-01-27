using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefabEnemy;

    public Transform SpawnLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        Instantiate (prefabEnemy, SpawnLocation.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
         SpawnEnemy();
    }
}

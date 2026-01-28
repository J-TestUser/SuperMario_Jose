using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] prefabEnemy;

    public Transform[] spawnPoints;

    public int enemiesSpawn = 5;

    private BoxCollider2D _boxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*void SpawnEnemy()
    {
        for (int i = 0; i < enemiesSpawn; i ++)// esto es un bucle. i es la variable del bucle, la cual empieza con valor 0 y como condición le hemos indicado que se repetirá hasta que el valor de i deje de ser menor que el de la variable enemiesSpawn.
        {
            Instantiate (prefabEnemy, SpawnLocation.position, Quaternion.identity); //genera una instancia de el enemigo y lo hace spawnear en la posición determinada por el objeto spawn position
        }
    
    }*/
    IEnumerator SpawnEnemy() //corrutina para spawnear enemigos.
    {
         for (int i = 0; i < enemiesSpawn; i ++)// esto es un bucle. i es la variable del bucle, la cual empieza con valor 0 y como condición le hemos indicado que se repetirá hasta que el valor de i deje de ser menor que el de la variable enemiesSpawn.
        {
            //Instantiate (prefabEnemy, spawnpoints[0].position, Quaternion.identity); //genera una instancia de el enemigo y lo hace spawnear en la posición determinada por el objeto spawn position. El número entre los corchetes determina el elemento de la lista del array que queremos utilizar.
            foreach (Transform item in spawnPoints)
            {
                Instantiate (prefabEnemy[Random.Range(0, prefabEnemy.Length)], item.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.5f); //determinamos con return que se detiene la corrutina, para luego volver a iniciarse al pasar 0,5 segundos
        }

    }


    void OnTriggerEnter2D(Collider2D collision)//función que se activa al entrar en colisión con un collider
    {
        if(collision.gameObject.CompareTag ("Player")) //condición que se actviar cuando el trigger del collider toque algo con la etiqueta Player
        {
            _boxCollider.enabled = false;//desactivamos el colider del enemy spawner para que no se pueda volver a activar
            StartCoroutine(SpawnEnemy());//llamamos a la corrutina
            // StartCourutine("SpawnEnemy");
        }

    }
}

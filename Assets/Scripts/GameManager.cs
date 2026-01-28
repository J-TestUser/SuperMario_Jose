using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int defeatedEnemies = 0;
    public int coinCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKill()
    {
        defeatedEnemies++;
    }

    public void AddCoin()
    {
        coinCount++;
    }
}

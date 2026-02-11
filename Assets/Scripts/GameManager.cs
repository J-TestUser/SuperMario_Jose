using UnityEngine;
using UnityEngine.UI; //necesario para poder trabajar con elemento de UI

public class GameManager : MonoBehaviour
{
    public int defeatedEnemies = 0;
    public int coinCount = 0;

    public bool _pause;

    public Text goombaText;
    public Text coinText;
    public Text gamingTime;
    public GameObject pauseCanvas;
    public int gameTime = 0;



    public void AddKill()
    {
        defeatedEnemies++;
        goombaText.text = "x"+ defeatedEnemies.ToString();
    }

    public void AddCoin()
    {
        coinCount++;
        coinText.text = "x"+ coinCount.ToString();

    }

    public void Pause()
    {
        if (_pause == false) //cuando el juego NO esté pausado y se ejecute la función
        {
            Time.timeScale = 0;
            _pause = true;
        }
        else
        {
            Time.timeScale = 1;
            _pause = false;
        }
        pauseCanvas.SetActive(_pause);//cojemos el valor de _pause.
        //Time.timeScale = 1; //reanuda el timepo del juego
        //Time.timeScale = 0.5 // ralentiza el tiempo dentro del juego
    }
    public void Chrono()
    {
        gameTime++;
    }
}

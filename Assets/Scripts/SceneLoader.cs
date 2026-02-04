using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ChangeScene(string sceneName)//string SceneName es un parametro que nos permite determinar que queremos, en este caso, un string corrspondiente al nombre de una escena.
    {
        SceneManager.LoadScene(sceneName);//Script interno de unity, se escribe tal cual (excepto el nombre o número de la escena)
        /*SceneManager.LoadSceneAsync("Level_1"); */ //El nivel se carga en segundo plano (versión para poer barra de carga)
        
    }
    //Esta es la forma de llamar a la función ChangeScene a traves de codigo...NO SE EJECUTA.
    void Test()
    {
        ChangeScene("Level_1");
    }
}

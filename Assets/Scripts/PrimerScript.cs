using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    private int numeroEntero = 5;
    private float numeroDecimal = 7.5f;
    private double decimalLargo = 8.4;
    private bool VerdaderoFalso = false;
    private string cadenaTexto = "Hola";
    //Variable para almacenar texto
    private char letra = 'a';
    //Variable para almacenar letras

    private int[] intArray = new int[5]{1, 9, 5 , 4, 3};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numeroEntero = 37;   
        intArray [2] = 8;
        cadenaTexto = "Hola Mundo";

        Debug.Log(cadenaTexto + " y Adiós!");
        Debug.Log(numeroEntero);
    }
    void Calculo()
    {

    }
    // Update is called once per frame
    void Update()
    {
        numeroEntero = 7 + 5;
        numeroEntero = 2 -7 ;
        numeroEntero = 6 * 9;
        numeroEntero = 4 / 3;

        numeroEntero = numeroEntero + 2;
        numeroEntero += 2;
    }
}

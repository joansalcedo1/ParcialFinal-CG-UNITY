using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prueba : MonoBehaviour
{
    //int valorMoneda;

    public float rangoX = 10f; // Rango en el eje X
    public float rangoZ = 10f; // Rango en el eje Z

    public GameObject arbol;

    public GameObject moneda;
    public Text textoMonedaOro;
    public Text textoMonedaSilver;

    //public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        moneda.SetActive(true);
        
    }
    private void Awake()
    {
        AparecerEnPosicionRandom();
    }
    
    
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (moneda.CompareTag("GoldenCoin"))
        {
        GameManager.instance.CoinsGold += 15;
        Debug.Log("Cantidad monedas " + GameManager.instance.CoinsGold);
        textoMonedaOro.text = GameManager.instance.CoinsGold.ToString();
        Debug.Log("agarraste la moneda de oro");
        moneda.SetActive(false);
        }
        else
        {
         GameManager.instance.CoinsSilver += 8;
         Debug.Log("Cantidad monedas " + GameManager.instance.CoinsSilver);
         textoMonedaSilver.text = GameManager.instance.CoinsSilver.ToString();
         Debug.Log("agarraste la moneda de silver");
         moneda.SetActive(false);
        }
    }

    void AparecerEnPosicionRandom()
    {
        // Genera una posición aleatoria dentro del rango especificado en los ejes X y Z
        float randomX = Random.Range(arbol.transform.localPosition.x-rangoX, arbol.transform.localPosition.y-rangoX);
        float randomZ = Random.Range(arbol.transform.localPosition.z-rangoZ, arbol.transform.localPosition.z+rangoZ);

        // Establece la posición del GameObject en la posición aleatoria generada
        transform.position = new Vector3(randomX, 0f, randomZ);
    }




}

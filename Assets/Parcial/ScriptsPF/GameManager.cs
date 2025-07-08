using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int CoinsGold;
    public int CoinsSilver;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
        //PlayerPrefs.DeleteAll();
    }
    void Start()
    {
        CoinsGold = 0;
        CoinsSilver = 0;
    }
    private void OnDestroy()
    {
        instance = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

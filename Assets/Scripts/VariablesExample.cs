using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesExample : MonoBehaviour
{
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        int vida = 100;
        string nomePersonagem = "Herói";
        Debug.Log(nomePersonagem + " tem " + vida + " pontos de vida!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTypeExamples : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float soma = 0;
        float media;
        float[] notas = new float[5];
        notas[0] = 7.5f;
        notas[1] = 8.0f;
        notas[2] = 9.5f;
        notas[3] = 5.5f;
        notas[4] = 8.5f;

        for (int i = 0; i < 5; i++) { soma = soma + notas[i]; }

        media = soma / notas.Length;

        Debug.Log(media);
    }
}
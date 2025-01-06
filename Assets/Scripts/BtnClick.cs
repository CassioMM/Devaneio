using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject cubo;
    [SerializeField]
    private Transform alvo;

    public void BtnC()
    {
        Instantiate(cubo, alvo.position, Quaternion.identity);


    }





}

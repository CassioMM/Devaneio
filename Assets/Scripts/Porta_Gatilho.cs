using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta_Gatilho : MonoBehaviour
{
    public Animator animaPorta;


    // Start is called before the first frame update
    void Start()
    {

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("TripaSeca"))
        {
            animaPorta.Play("PortaAnim");

        }
    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("TripaSeca"))
        {
            animaPorta.Play("PortaAnimNegativo");

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Documento : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;

    private DocController dc;

    bool docActive = false;
    


    // Start is called before the first frame update
    void Start()
    {
        dc = FindObjectOfType<DocController>();
    }

    // Update is called once per frame
    public void vc()
    {
        docActive = !docActive;
        dc.Speech(profile, speechTxt);
        

        

        /*if (docActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }*/

    }
}

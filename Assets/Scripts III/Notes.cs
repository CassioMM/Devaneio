using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notes : MonoBehaviour
{
    [SerializeField]
    public Image _noteImage;
    [SerializeField]
    private Image buttonI;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private Button buttonX;

    //public GameObject documento;
    public BoxCollider documento;

    public GameObject MessagePanel;
    public bool Action = false;


    void Start()
    {
        MessagePanel.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Action == true)
            {
                //MessagePanel.SetActive(true);
                _noteImage.enabled = true;
                text.enabled = true;
                buttonX.enabled = true;
                buttonI.enabled = true;
                Action = false;

            }
        }

        /*if (_noteImage.enabled == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }*/

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TripaSeca"))
        {
            MessagePanel.SetActive(true);
            Action = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TripaSeca"))
        {
            MessagePanel.SetActive(false);
            Action = false;
            _noteImage.enabled = false;
            text.enabled = false;
            buttonX.enabled = false;
            buttonI.enabled = false;

        }
    }


}

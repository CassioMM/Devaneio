using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractiveDoc : MonoBehaviour
{
    private InterfaceController iController;

    private Documento doc;


    // Start is called before the first frame update
    void Start()
    {
        iController = FindObjectOfType<InterfaceController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.collider.tag == "Doc")
            {
                iController.itemText.text = "read me (C)";

                if (Input.GetKeyDown(KeyCode.C))
                {

                    doc.vc();

                }
            }
            else if (hit.collider.tag != "Doc")
            {
                iController.itemText.text = null;

            }
        }

    }
}

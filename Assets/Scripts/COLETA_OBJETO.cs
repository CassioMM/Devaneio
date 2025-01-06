using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COLETA_OBJETO : MonoBehaviour
{
    [SerializeField]
    private int itens = 0;
    [SerializeField]
    private Text txt;
    [SerializeField]
    private Image img;
    [SerializeField]
    private RawImage imgR;
    private Rect aux;

    // Start is called before the first frame update
    void Start()
    {
        aux = new Rect(imgR.uvRect);

        img.fillAmount = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        aux.x += 0.1f * Time.deltaTime;
        //imgR.uvRect = aux;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("item"))
        {
            Destroy(col.gameObject);
            itens += 1;
            txt.text = itens.ToString();
        }
    }

}

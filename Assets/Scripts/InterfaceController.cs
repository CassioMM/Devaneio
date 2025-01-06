using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{

    public GameObject PausePainel;

    public Text itemText;

    public AudioSource audioMenu;

    public GameObject[] itensPause;
    public GameObject[] itensConfig;

    bool pauseActive = false;
    bool onRadious = false;
    bool cntrlActive = true;




    void Start()
    {


    }


    void Update()
    {

        //Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseActive =! pauseActive;
            PausePainel.SetActive(pauseActive);
            audioMenu.Play();

        }


        if (pauseActive == true || onRadious == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


    public void Resume()
    {
        pauseActive =! pauseActive;
        PausePainel.SetActive(pauseActive);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Configuracoes()
    {
        for (int i = 0; i < itensPause.Length; i++)
        {
            itensPause[i].SetActive(false);
        }

        for (int i = 0; i < itensConfig.Length; i++)
        {
            itensConfig[i].SetActive(true);
        }
    }

    public void ExitConfiguracoes()
    {
        for (int i = 0; i < itensConfig.Length; i++)
        {
            itensConfig[i].SetActive(false);
        }

        for (int i = 0; i < itensPause.Length; i++)
        {
            itensPause[i].SetActive(true);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocController : MonoBehaviour
{
    [Header("Components")]
    public GameObject documentObj;
    public Image profile;
    public Text speechText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;



    public void Speech(Sprite p, string[] txt)
    {
        documentObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        StartCoroutine(TypeSentence());

    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {

            //ainda há textos
            if (index <= sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //lido quando acaba os textos
            {
                speechText.text = " ";
                index = 0;
                documentObj.SetActive(false);


            }

        }

    }
}

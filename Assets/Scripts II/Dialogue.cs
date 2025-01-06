using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject NPC;
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;

    public GameObject TXT;

    public float radious;
    public LayerMask playerLayer;

    private DialogueControl dc;

    bool onRadious;
    bool Falando = false;

    
    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
        
    }

    private void FixedUpdate()
    {
        Interact(/*onRadious*/);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && onRadious && Falando == false)
        {
            //onRadious = true;
            dc.Speech(profile, speechTxt, actorName);
            Falando = true;
            //Player.CancelControler(false);
        }

        if (Input.GetKeyDown(KeyCode.Z) && Falando == true)
        {
            dc.NextSentence();
            

        }

    }

    public void Interact(/*bool value*/)
    {
        Collider2D hit = Physics2D.OverlapCircle(NPC.transform.position, radious, playerLayer);

        if(hit != null)
        {
            TXT.SetActive(true);
            onRadious = true;

        }
        else if(hit == null)
        {
            TXT.SetActive(false);
            onRadious = false;
            Falando = false;
        }
    }

    //desenha o raio da colisão
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }



}

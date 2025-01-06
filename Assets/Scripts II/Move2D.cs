using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction;

    public Animator animator;

    private Vector3 facingRight;
    private Vector3 facingLeft;

    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEhChao;
    public Collider2D slahks;

    public float IntiX, InteY;

    public int pulosExtras = 1;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (direction > 0)
        {
            //olhando para a direita
            transform.localScale = facingRight;
        }

        if (direction < 0)
        {
            //olhando para a direita
            transform.localScale = facingLeft;
        }


        if (canMove)
        {
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);


            if (Input.GetAxis("Horizontal") != 0)
            {
                //esta correndo
                animator.SetBool("taCorrendo", true);

            }
            else
            {
                //esta parado
                animator.SetBool("taCorrendo", false);
            }


            taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEhChao);

            if (Input.GetButtonDown("Jump2D") && taNoChao == true)
            {
                rb.velocity = Vector2.up * 12;

                // ativar a animação do pulo
                animator.SetBool("taPulando", true);
            }

            if (Input.GetButtonDown("Jump2D") && taNoChao == false && pulosExtras > 0)
            {
                rb.velocity = Vector2.up * 12;
                pulosExtras--;

                // ativar a animação do pulo duplo
                animator.SetBool("puloDuplo", true);
            }

            if (taNoChao && rb.velocity.y == 0)
            {
                pulosExtras = 1;
                animator.SetBool("taPulando", false);
                animator.SetBool("puloDuplo", false);
            }

        }

    }

    public void CancelControler(bool value)
    {
        canMove = value;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer  == 3)
        {
            animator.SetBool("taPulando", false);
            animator.SetBool("puloDuplo", false);
            pulosExtras = 1;

        }

        if (collision.gameObject.tag == "Platform")
        {
            //gameObject.transform.parent.position = collision.transform.position;
            gameObject.transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "Finish")
        {
            StartCoroutine(TP());
        }

        if (collision.gameObject.tag == "Respawn")
        {
            StartCoroutine(LoadLevelTransition(SceneManager.GetActiveScene().buildIndex + 1));
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.transform.parent = null;
        }


    }

    IEnumerator TP()
    {
        canMove = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector3(IntiX, InteY, 0);
        yield return new WaitForSeconds(0.1f);
        canMove = true;
    }

    IEnumerator LoadLevelTransition(int levelIndex)
    {
        yield return null;

        SceneManager.LoadScene(levelIndex);


    }

}

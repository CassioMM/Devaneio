using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



[System.Serializable]
public class PlayerMovimnt : MonoBehaviour
{
    public float heath = 100f;
    public float time = 3f;

    public CharacterController controller;
    public float speed = 6f;
    public float runningSpeed = 9f;
    public float gravity = -10f;
    public float jumpHeigth;
    public Animator anim;
    public GameObject sangueNaTela;
    public GameObject feitiçoNaTela;
    public GameObject QuickTime;
    public float QuickValue = 50f;
    public int damage = 20;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    public MonsterIARA MIara;

    public Vector3 velocity = Vector3.zero;
    bool isGrounded;
    float initialSpeed;
    bool canMove = true;
    public bool canG = true;

    public AudioSource Damage;
    public AudioSource Feitiço;

    [SerializeField] private AudioSource passosAudioSource;
    [SerializeField] private AudioClip[] passosAudioClip;
    public float passosAudioSourceV = 0.478f;
    public float DamageV = 0.478f;


    void Start()
    {
        initialSpeed = speed;

        sangueNaTela.SetActive(false);
        QuickTime.SetActive(false);

    }

    
    void Update()
    {

        /*if (Stoned == true)
        {
            speed = 1f;
            runningSpeed = 3f;
        }

        if (Stoned == false)
        {
            speed = 3f;
            runningSpeed = 9f;

        }*/

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeigth * -2f * gravity);
        }


        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;


        if (canMove)
        {
            controller.Move(speed * Time.deltaTime * move);

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        if (controller.isGrounded)
        {
            if (moveZ != 0)
            {
                anim.SetBool("Parado", false);
                anim.SetBool("Andando", true);
            }
            else
            {
                anim.SetBool("Parado", true);
                anim.SetBool("Andando", false);
            }


        }

        if (heath <= 0)
        {
            anim.SetBool("Morte", true);
            speed = 0;
            StartCoroutine("morte");

        }
    }


    public void CancelControler(bool value)
    {
        canMove = value;

    }

    private void OnTriggerEnter(Collider collider)
    {
        //DecreaseTime(true);
        /*if (canG)
        {
            if (collider.gameObject.tag == "maoInimigo" || collider.gameObject.tag == "Encanto")
            {
                if (collider.gameObject.tag == "maoInimigo")
                {
                    StartCoroutine(DamageCoroutine());
                    sangueNaTela.SetActive(true);
                    Damage.Play();
                }


                if (collider.gameObject.tag == "Encanto")
                {
                    QuickFuncion();
                    QuickTime.SetActive(true);
                    feitiçoNaTela.SetActive(true);
                    //Feitiço.Play();
                }


                //Feitiço.Play();

                //StartCoroutine(DamageCoroutine());
                //QuickFuncion();

                /*heath -= 4f;
                speed = 3f;
                runningSpeed = 3f;
                Invoke("resetSpeed", 3);*/

                /*feitiçoNaTela.SetActive(true);
                sangueNaTela.SetActive(true);

            }
        }*/
            

        if (collider.gameObject.tag == "maoInimigo")
        {
            StartCoroutine(DamageCoroutine());
            sangueNaTela.SetActive(true);
            Damage.Play();
            Damage.volume = DamageV;
        }

        if (canG)
        {
            if (collider.gameObject.tag == "Encanto")
            {
                StartCoroutine(QuickFuncion());
                QuickTime.SetActive(true);
                feitiçoNaTela.SetActive(true);
                //Feitiço.Play();
            }

        }
        
        if(canG == false)
        {
            QuickTime.SetActive(false);
            feitiçoNaTela.SetActive(false);

        }

        /*if (collider.gameObject.tag == "maoInimigo")
        {

            Damage.Play();

            StartCoroutine(DamageCoroutine());

            heath -= 4f;
            speed = 3f;
            runningSpeed = 3f;
            Invoke("resetSpeed", 3);

            sangueNaTela.SetActive(true);
            QuickTime.SetActive(true);
        }*/

    }

    private void resetSpeed()
    {
        speed = 6f;
        runningSpeed = 12f;
        canG = true;

    }

    private IEnumerator DamageCoroutine()
    {
        //QuickValue -= .98f;
        heath -= 2f;
        speed = 3f;
        runningSpeed = 3f;
        yield return new WaitForSeconds(3f);
        resetSpeed();
        yield return new WaitForSeconds(1f);
        sangueNaTela.SetActive(false);


    }


    private IEnumerator QuickFuncion()
    {

        speed = 0f;
        runningSpeed = 0f;

        if (canG)
        {
            QuickValue -= .98f;
        }
        //QuickValue -= .98f;
        //feitiçoNaTela.SetActive(true);

        if (Input.GetKey(KeyCode.F) && QuickValue < 100f)
        {
            QuickValue += 5f;

        }

        if (QuickValue >= 100f)
        {
            StartCoroutine(MIara.DamageCoroutine());
            canG = false;
            speed = 6f;
            runningSpeed = 12f;
            yield return new WaitForSeconds(1f);
            resetSpeed();


            feitiçoNaTela.SetActive(false);
            QuickTime.SetActive(false);


        }


    }

    void morte()
    {
        SceneManager.LoadScene("Game Over"); //temporario
        //SceneManager.LoadScene("Menu");
    }

    public void PersoV(float value)
    {

        passosAudioSourceV = value;
        DamageV = value;

    }

    public void QuickTimeEvent(float value)
    {

        QuickValue = 50;

    }

    private void Passos()
    {
        passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
        passosAudioSource.volume = passosAudioSourceV;
    }

}

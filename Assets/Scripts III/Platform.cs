using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float posEsta;
    public float posVai;

    public bool moveRight;
    public bool moveUp;
    public bool UP;

    void Update()
    {
        if (UP)
        {
            if (transform.position.y > posEsta)
            {
                moveUp = false;
            }
            else if (transform.position.y < posVai)
            {
                moveUp = true;
            }

            if (moveUp)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
            }
        }


        if (!UP)
        {
            if (transform.position.x > posEsta)
            {
                moveRight = false;
            }
            else if (transform.position.x < posVai)
            {
                moveRight = true;
            }

            if (moveRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
            }
        }
        
    }
}

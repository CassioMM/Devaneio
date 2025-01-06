using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTP : MonoBehaviour
{
    Monster monster;

    void Start()
    {
        monster = gameObject.GetComponent<Monster>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine("TP");           
        }
    }

    IEnumerator TP()
    {
        monster.canMove = false;
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = new Vector3(25, 0, 0);
        yield return new WaitForSeconds(1f);
        monster.canMove = true;
    }

}

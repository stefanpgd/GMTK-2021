using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollision();
    }

    private void CheckCollision()
    {
        Collider[] collider = Physics.OverlapBox(transform.position, new Vector3(1, 1, 1));

        for (int i = 0; i < collider.Length; i++)
        {
            Debug.Log("Attacked with a collider");

            Destroy(collider[i].gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
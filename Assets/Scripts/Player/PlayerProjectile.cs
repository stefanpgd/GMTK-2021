using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField]
    private int m_Damage;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_MaxTravelTime;
    private float m_CurrentTravelTime = 0;

    private void Start()
    {
        m_CurrentTravelTime = 0;
    }

    private void Update()
    {
        transform.position += transform.forward * m_Speed * Time.deltaTime;

        m_CurrentTravelTime += Time.deltaTime;

        // disabled for now, player got removed aswell
        //CheckCollision(); 

        if(m_CurrentTravelTime >= m_MaxTravelTime)
        {
            Destroy(gameObject);
        }
    }


    private void CheckCollision()
    {
        Collider[] collider = Physics.OverlapBox(transform.position, new Vector3(1, 1, 1));

        for(int i = 0; i < collider.Length; i++)
        {
            Debug.Log("Projectile hit a collider");

            Destroy(collider[i].gameObject);
        }
    }

    // Stefan:
    // Probably want the let enemy check if it got hit by a bullet instead of the other way around
    // Maybe let the bullet check if it hit a boundary ( walls ) and if so, then destroy itself
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
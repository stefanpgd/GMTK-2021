using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_MaxTravelTime;
    private float m_CurrentTravelTime = 0;

    private void Awake()
    {
        m_CurrentTravelTime = 0;
    }

    private void Update()
    {
        transform.position += transform.forward * m_Speed * Time.deltaTime;

        m_CurrentTravelTime += Time.deltaTime;

        // disabled for now, player got removed aswell
        CheckCollision();

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
            if (collider[i].tag == "Wall")
            {
                Debug.Log("Projectile hit a wall");

                Destroy(gameObject);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Burst;

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

    // Checks when it has collision with a wall
    private void CheckCollision()
    {
        // Via overlapbox checks if it collides with something that has a collider
        Collider[] collider = Physics.OverlapBox(transform.position, transform.localScale);

        for(int i = 0; i < collider.Length; i++)
        {
            if (collider[i].tag == "Wall")
            {
                Debug.Log("Projectile hit a wall");

                GameObject effect = Instantiate(m_Burst, transform.position, m_Burst.transform.rotation);
                Destroy(effect, 1f);

                Destroy(gameObject);
            }
        }
    }
}
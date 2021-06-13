using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private GameObject m_Burst;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            GameObject effect = Instantiate(m_Burst, transform.position, m_Burst.transform.rotation);
            Destroy(effect, 1f);

            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Body"))
        {
            GameObject effect = Instantiate(m_Burst, transform.position, m_Burst.transform.rotation);
            Destroy(effect, 1f);

            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Soul"))
        {
            GameObject effect = Instantiate(m_Burst, transform.position, m_Burst.transform.rotation);
            Destroy(effect, 1f);

            Destroy(gameObject);
        }
    }
}

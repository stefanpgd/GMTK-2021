using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    private Movement m_Movement;

    // Start is called before the first frame update
    void Start()
    {
        m_Movement = FindObjectOfType<Movement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wall"))
            m_Movement.m_CanSwitch = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
            m_Movement.m_CanSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

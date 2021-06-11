using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //
    public NavMeshAgent agent;

    //
    public Transform playerBody;
    public Transform playerSoul;

    //
    public float Health;

    //
    public bool attackBody; //if true attacks body, if false attacks soul

    private void Awake()
    {
        
    }

    private void Start()
    {
        playerBody = GameObject.Find("Body").transform;
        playerSoul = GameObject.Find("Soul").transform;

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(attackBody)
        {
            ChaseBody();
        }
        else
        {
            ChaseSoul();
        }
    }

    private void ChaseBody()
    {
        agent.SetDestination(playerBody.position);
    }

    private void ChaseSoul()
    {
        agent.SetDestination(playerSoul.position);
    }

    private void TakeDamage()
    {
        Debug.Log("lol enemy ai heeft een projectile gegeten");

        Health--;

        if(Health <= 0)
        {
            //Call enemy manager who keeps track of all enemies
            //Destroy enemy object
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            Destroy(other);
            TakeDamage();
        }
    }
}

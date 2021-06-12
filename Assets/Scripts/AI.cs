using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //
    public NavMeshAgent agent;

    //
    public Sprite bodySprite;
    public Sprite soulSprite;
    //
    public Transform playerBody;
    public Transform playerSoul;

    //
    public float bodyHealth;
    public float ghostHealth;
    //
    public bool attackBody; //if true attacks body, if false attacks soul
    public bool isSoul; //if true enemy is in soul form, if false enemy is in body form

    private void Awake()
    {
        SwitchColours();
        UpdatePosition();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (attackBody == true)
        {
            ChaseBody();
        }
        else if (attackBody == false)
        {
            ChaseSoul();
        }

        if(Movement.m_HasSwitched == true)
        {
            UpdatePosition();
        }

        //Testing if it works
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SwitchColours();
            isSoul = !isSoul;
            attackBody = !attackBody;
        }
    }

    private void UpdatePosition()
    {
        playerBody = GameObject.FindGameObjectWithTag("Body").transform;
        playerSoul = GameObject.FindGameObjectWithTag("Soul").transform;

        Movement.m_HasSwitched = false;
    }

    private void ChaseBody()
    {
        agent.SetDestination(playerBody.position);
    }

    private void ChaseSoul()
    {
        agent.SetDestination(playerSoul.position);
    }

    private void TakeDamage(float amount)
    {
        Debug.Log("lol enemy ai heeft een projectile gegeten");

        if(isSoul == false)
        {
            bodyHealth -= amount;

            if (bodyHealth <= 0)
            {
                SwitchColours();

                attackBody = false;
                isSoul = true;
            }
        }

        else if(isSoul == true)
        {
            ghostHealth -= amount;

            if (ghostHealth <= 0)
            {
                //Call enemy manager who keeps track of all enemies
                //Destroy enemy object
            }
        }
    }

    private void SwitchColours()
    {
        //if enemy switches from body to soul it changes sprite
        if (isSoul == false)
        {
            transform.GetComponentInChildren<SpriteRenderer>().sprite = bodySprite;
        }
        else if (isSoul == true)
        {
            transform.GetComponentInChildren<SpriteRenderer>().sprite = soulSprite;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            Destroy(other);
            TakeDamage(GameVariables.PROJECTILE_DAMAGE);
        }
        else if(other.tag == "Weapon")
        {
            TakeDamage(GameVariables.SWORD_DAMAGE);
        }
    }
}

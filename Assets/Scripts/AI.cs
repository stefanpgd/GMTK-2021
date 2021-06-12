using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    private Collider collider;
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
    public float soulHealth;
    public float soulSpeed;
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
        collider = GetComponent<Collider>();
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

        if (transform.position.x > playerBody.position.x)
        {
            m_SpriteRenderer.flipX = false;
        }

        else
        {
            m_SpriteRenderer.flipX = true;
        }
    }

    private void ChaseSoul()
    {
        //agent.SetDestination(playerSoul.position);

        //float speed = soulSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerSoul.position, soulSpeed);


        if (transform.position.x > playerSoul.position.x)
        {
            m_SpriteRenderer.flipX = false;
        }

        else
        {
            m_SpriteRenderer.flipX = true;
        }
    }

    private void TakeDamage(float amount)
    {
        Debug.Log("lol enemy ai heeft een projectile gegeten");

        if(isSoul == false)
        {
            bodyHealth -= amount;

            if (bodyHealth <= 0)
            {
                attackBody = false;
                isSoul = true;

                SwitchColours();
            }
        }

        else if(isSoul == true)
        {
            soulHealth -= amount;

            if (soulHealth <= 0)
            {
                //Call enemy manager who keeps track of all enemies
                //Destroy enemy object
                Destroy(gameObject);
            }
        }
    }

    private void SwitchColours()
    {
        //if enemy switches from body to soul it changes sprite
        if (isSoul == false)
        {
            transform.GetComponentInChildren<SpriteRenderer>().sprite = bodySprite;
            collider.isTrigger = true;
        }
        else if (isSoul == true)
        {
            transform.GetComponentInChildren<SpriteRenderer>().sprite = soulSprite;
            collider.isTrigger = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            Destroy(other.gameObject);
            TakeDamage(GameVariables.PROJECTILE_DAMAGE);
        }
        else if(other.tag == "Weapon")
        {
            TakeDamage(GameVariables.SWORD_DAMAGE);
        }
    }
}

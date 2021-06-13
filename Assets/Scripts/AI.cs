using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private GameObject m_Blood;
    [SerializeField] private float speed;
    [SerializeField] private float wallAvoidanceSpeed;
    [SerializeField] private float maxForce;
    [SerializeField] private float maxVelocity;

    private Vector3 velocity;
    private Vector3 acceralation;
    private Vector3 location;

    private Collider collider;
    private Animator m_Animator;

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
        collider = GetComponent<Collider>();

        SwitchColours();
        UpdatePosition();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
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


        acceralation = Vector3.zero;
    }

    private void UpdatePosition()
    {
        playerBody = GameObject.FindGameObjectWithTag("Body").transform;
        playerSoul = GameObject.FindGameObjectWithTag("Soul").transform;

        Movement.m_HasSwitched = false;
    }

    private void ChaseBody()
    {
        Vector3 direction = playerBody.position - transform.position;
        direction.Normalize();
        direction *= speed;
        LimitForce(ref direction);

        location = transform.position;
        acceralation += direction;
        velocity += acceralation;
        LimitVelocity();
        velocity = new Vector3(velocity.x, 0f, velocity.z);
        location += velocity * Time.deltaTime;
        transform.position = location;

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
        transform.position = Vector3.MoveTowards(transform.position, playerSoul.position, soulSpeed);
        velocity = Vector3.zero;

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

        GameObject effect = Instantiate(m_Blood, transform.position, m_Blood.transform.rotation);
        Destroy(effect, 1f);

        if (isSoul == false)
        {
            bodyHealth -= amount;

            if (bodyHealth <= 0)
            {
                attackBody = false;
                isSoul = true;
                m_Animator.SetTrigger("Soul");

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
            //collider.isTrigger = true;
        }
        else if (isSoul == true)
        {
            transform.GetComponentInChildren<SpriteRenderer>().sprite = soulSprite;
            //collider.isTrigger = false;
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

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            Vector3 pushForce = transform.position - other.gameObject.transform.position;
            pushForce.Normalize();
            pushForce *= wallAvoidanceSpeed;
            LimitForce(ref pushForce);
            acceralation += pushForce;
        }
    }

    private void LimitForce(ref Vector3 force)
    {
        if(force.magnitude > maxForce)
        {
            force.Normalize();
            force *= maxForce;
        }
    }

    private void LimitVelocity()
    {
        if(velocity.magnitude > maxVelocity)
        {
            velocity.Normalize();
            velocity *= maxVelocity;
        }
    }
}

using UnityEngine;
using SilverRogue.Tools;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform m_Soul;
    [SerializeField] private float m_Speed;
    [SerializeField] private float m_SwitchCooldownTime;
    [SerializeField] private Material m_BodyColor, m_SoulColor;
    [SerializeField] private Transform m_PivotBody, m_PivotSoul;

    [SerializeField] private Animator m_BodyAnim, m_SoulAnim;
    [SerializeField] private SpriteRenderer m_BodySprite, m_SoulSprite;
    [SerializeField] private Sprite m_SwordBody, m_SwordSoul, m_GunBody, m_GunSoul;

    public bool m_CanSwitch = true;
    public static bool m_HasSwitched;

    private bool m_IsSoul;
    private float m_LastPosition;
    private Camera m_MainCamera;
    private Timer m_SwitchCooldown;

    void Start()
    {
        m_MainCamera = Camera.main;
        m_SwitchCooldown = new Timer(m_SwitchCooldownTime);
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wall"))
            m_CanSwitch = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
            m_CanSwitch = true;
    }
    */

    // Update is called once per frame
    void Update()
    {
        /*
        //Source: https://answers.unity.com/questions/760900/how-can-i-rotate-a-gameobject-around-z-axis-to-fac.html
        Vector2 mousPos = m_MainCamera.ScreenToWorldPoint(Input.mousePosition);

        //Get Angle in Radians
        float angleRad = Mathf.Atan2(mousPos.y - transform.position.y, mousPos.x - transform.position.x);
        float angleRad2 = Mathf.Atan2(mousPos.y - m_Soul.position.y, mousPos.x - m_Soul.position.x);

        //Get Angle in Degrees
        float angleDeg = (180 / Mathf.PI) * angleRad;
        float angleDeg2 = (180 / Mathf.PI) * angleRad2;

        //Rotate Object
        transform.rotation = Quaternion.Euler(0, 0, angleDeg);
        m_Soul.rotation = Quaternion.Euler(0, 0, angleDeg2);
        */

        //Source: https://answers.unity.com/questions/1699631/player-rotating-towards-mouse-3d.html
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

            m_PivotBody.LookAt(new Vector3(pointToLook.x, m_PivotBody.position.y, pointToLook.z));
            m_PivotSoul.LookAt(new Vector3(pointToLook.x, m_PivotSoul.position.y, pointToLook.z));

            if (pointToLook.x > transform.position.x)
            {
                m_BodySprite.flipX = false;
            }

            else
            {
                m_BodySprite.flipX = true;
            }

            if (pointToLook.x > m_PivotSoul.position.x)
            {
                m_SoulSprite.flipX = false;
            }

            else
            {
                m_SoulSprite.flipX = true;
            }
        }
        //

        if (m_SwitchCooldown.Expired)
        {
            if (Input.GetMouseButtonUp(1))
            {
                if (m_CanSwitch)
                {
                    m_IsSoul = !m_IsSoul;
                    m_HasSwitched = true;

                    //Sword guy wordt soul
                    if (m_IsSoul)
                    {
                        transform.GetComponent<MeshRenderer>().material = m_SoulColor;
                        m_Soul.GetComponent<MeshRenderer>().material = m_BodyColor;

                        GetComponent<BoxCollider>().isTrigger = true;
                        m_Soul.GetComponent<BoxCollider>().isTrigger = false;

                        m_BodySprite.sprite = m_SwordSoul;
                        m_BodySprite.color = new Color(255, 255, 255, 0.7f);
                        m_SoulSprite.sprite = m_GunBody;
                        m_SoulSprite.color = new Color(255, 255, 255, 1f);

                        m_Soul.transform.gameObject.tag = "Body";
                        transform.gameObject.tag = "Soul";
                    }

                    //Gun guy wordt soul
                    else
                    {
                        transform.GetComponent<MeshRenderer>().material = m_BodyColor;
                        m_Soul.GetComponent<MeshRenderer>().material = m_SoulColor;

                        GetComponent<BoxCollider>().isTrigger = false;
                        m_Soul.GetComponent<BoxCollider>().isTrigger = true;

                        m_BodySprite.sprite = m_SwordBody;
                        m_BodySprite.color = new Color(255, 255, 255, 1f);
                        m_SoulSprite.sprite = m_GunSoul;
                        m_SoulSprite.color = new Color(255, 255, 255, 0.7f);

                        m_Soul.transform.gameObject.tag = "Soul";
                        transform.gameObject.tag = "Body";
                    }

                    m_SwitchCooldown.Restart();
                }

                m_CanSwitch = true;
            }
        }
    }

    private void FixedUpdate()
    {
        //Hiermee kan de speler met de WASD en/of Pijltjes toetsen rond bewegen.
        if (!m_IsSoul)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    transform.Translate(Vector3.right * m_Speed * Time.deltaTime, Space.World);
                }

                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    transform.Translate(Vector3.left * m_Speed * Time.deltaTime, Space.World);
                }
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    transform.Translate(Vector3.forward * m_Speed * Time.deltaTime, Space.World);
                }

                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    transform.Translate(Vector3.back * m_Speed * Time.deltaTime, Space.World);
                }
            }

            m_Soul.position = new Vector3(-transform.position.x, 0, -transform.position.z);

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                m_BodyAnim.SetBool("Walking", true);
                m_SoulAnim.SetBool("Floating", true);
            }

            else
            {
                m_BodyAnim.SetBool("Walking", false);
                m_SoulAnim.SetBool("Floating", false);
            }

            m_BodyAnim.SetBool("Floating", false);
            m_SoulAnim.SetBool("Walking", false);
        }

        else
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    m_Soul.Translate(Vector3.right * m_Speed * Time.deltaTime, Space.World);
                }

                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    m_Soul.Translate(Vector3.left * m_Speed * Time.deltaTime, Space.World);
                }
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    m_Soul.Translate(Vector3.forward * m_Speed * Time.deltaTime, Space.World);
                }

                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    m_Soul.Translate(Vector3.back * m_Speed * Time.deltaTime, Space.World);
                }
            }

            transform.position = new Vector3(-m_Soul.position.x, 0, -m_Soul.position.z);

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                m_BodyAnim.SetBool("Floating", true);
                m_SoulAnim.SetBool("Walking", true);
            }

            else
            {
                m_BodyAnim.SetBool("Floating", false);
                m_SoulAnim.SetBool("Walking", false);
            }

            m_BodyAnim.SetBool("Walking", false);
            m_SoulAnim.SetBool("Floating", false);
        }
    }
}

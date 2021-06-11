using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform m_Soul;
    [SerializeField] private float m_Speed;
    [SerializeField] private Material m_BodyColor, m_SoulColor;

    public bool m_CanSwitch = true;

    private bool m_IsSoul;
    private float m_LastPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        m_CanSwitch = false;
    }

    private void OnTriggerExit(Collider other)
    {
        m_CanSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Source: https://answers.unity.com/questions/760900/how-can-i-rotate-a-gameobject-around-z-axis-to-fac.html
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get Angle in Radians
        float angleRad = Mathf.Atan2(mousPos.y - transform.position.y, mousPos.x - transform.position.x);
        float angleRad2 = Mathf.Atan2(mousPos.y - m_Soul.position.y, mousPos.x - m_Soul.position.x);

        // Get Angle in Degrees
        float angleDeg = (180 / Mathf.PI) * angleRad;
        float angleDeg2 = (180 / Mathf.PI) * angleRad2;

        // Rotate Object
        transform.rotation = Quaternion.Euler(0, 0, angleDeg);
        m_Soul.rotation = Quaternion.Euler(0, 0, angleDeg2);

        if (Input.GetMouseButtonUp(1))
        {
            if (m_CanSwitch)
            {
                m_IsSoul = !m_IsSoul;

                if (m_IsSoul)
                {
                    transform.GetComponent<MeshRenderer>().material = m_SoulColor;
                    m_Soul.GetComponent<MeshRenderer>().material = m_BodyColor;

                    GetComponent<BoxCollider>().isTrigger = true;
                    m_Soul.GetComponent<BoxCollider>().isTrigger = false;
                }

                else
                {
                    transform.GetComponent<MeshRenderer>().material = m_BodyColor;
                    m_Soul.GetComponent<MeshRenderer>().material = m_SoulColor;

                    GetComponent<BoxCollider>().isTrigger = false;
                    m_Soul.GetComponent<BoxCollider>().isTrigger = true;
                }
            }

            m_CanSwitch = true;
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
                    transform.Translate(Vector3.up * m_Speed * Time.deltaTime, Space.World);
                }

                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    transform.Translate(Vector3.down * m_Speed * Time.deltaTime, Space.World);
                }
            }

            m_Soul.position = new Vector3(-transform.position.x, -transform.position.y, 0);
        }

        else
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    transform.Translate(Vector3.left * m_Speed * Time.deltaTime, Space.World);
                    m_Soul.Translate(Vector3.right * m_Speed * Time.deltaTime, Space.World);
                }

                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    transform.Translate(Vector3.right * m_Speed * Time.deltaTime, Space.World);
                    m_Soul.Translate(Vector3.left * m_Speed * Time.deltaTime, Space.World);
                }
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    transform.Translate(Vector3.down * m_Speed * Time.deltaTime, Space.World);
                    m_Soul.Translate(Vector3.up * m_Speed * Time.deltaTime, Space.World);
                }

                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    transform.Translate(Vector3.up * m_Speed * Time.deltaTime, Space.World);
                    m_Soul.Translate(Vector3.down * m_Speed * Time.deltaTime, Space.World);
                }
            }

            transform.position = new Vector3(-m_Soul.position.x, -m_Soul.position.y, 0);
        }
    }
}

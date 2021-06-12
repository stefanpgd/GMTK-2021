using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    private ExitDoor m_Door;

    // Start is called before the first frame update
    void Start()
    {
        m_Door = FindObjectOfType<ExitDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        m_Door.NextLevel();
    }
}

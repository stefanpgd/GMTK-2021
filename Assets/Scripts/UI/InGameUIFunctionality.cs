using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIFunctionality : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject PausePanel;

    private bool pauseScreenState = false;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(pauseScreenState = !pauseScreenState);
            //pauseScreenState = !pauseScreenState;
        }
    }
}
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
            /* Disgusting but it works.
             * PausePanel.SetActive(pauseScreenState = !pauseScreenState);
            */
            SetPauseState(!pauseScreenState);
        }
    }

    public void SetPauseState(bool state)
    {
        PausePanel.SetActive(state);
        GameTime.SetTimeScale(state == true ? 0f : 1f);
        pauseScreenState = state;
    }
}
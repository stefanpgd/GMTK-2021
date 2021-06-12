using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIFunctionality : MonoBehaviour
{
    // Variables
    [Header("IDK")]
    [SerializeField] private GameObject bodyUI;
    private bool bodyState = true;
    [SerializeField] private GameObject soulUI;

    [Space(10)]

    [SerializeField] private GameObject PausePanel;

    private bool pauseScreenState = false;
    
    void Start()
    {
        soulUI.SetActive(false);
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

    // Set the new state of the Body or Soul UI, True = Body, False is Soul icon.
    public void SetBodyStateUI(bool state)
    {
        bodyUI.SetActive(state);
        soulUI.SetActive(!state);
        bodyState = state;
    }
}
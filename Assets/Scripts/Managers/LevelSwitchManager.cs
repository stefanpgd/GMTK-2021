using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class LevelSwitchManager : MonoBehaviour
{
    public static LevelSwitchManager Instance;

    [SerializeField] List<GameObject> m_levels;
    [SerializeField] private Animator shopAnimator;

    GameObject m_currentlevel;

    private string nextLevelToLoad;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        m_currentlevel = m_levels[0];
    }

    public void LevelFinished(string nextLevel)
    {
        nextLevelToLoad = nextLevel;
        shopAnimator.SetBool("Open", true);
    }

    // Shop Manager calls the 'LoadNextLevel' whenever the Exit Button is pressed
    public void LoadNextLevel()
    {
        m_currentlevel.SetActive(false);

        shopAnimator.SetBool("Open", false);

        for(int l = 0; l < m_levels.Count; l++)
        {
            if(m_levels[l].name == nextLevelToLoad) 
            {
                m_levels[l].SetActive(true);
                m_currentlevel = m_levels[l];
            }
        }
    }
}

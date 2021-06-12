using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchManager : MonoBehaviour
{
    public static LevelSwitchManager Instance;

    [SerializeField] List<GameObject> m_levels;

    GameObject m_currentlevel;

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
        for (int l = 0; l < m_levels.Count; l++)
        {
            m_levels[l].SetActive(false);
        }

        m_levels[0].SetActive(true);
        m_currentlevel = m_levels[0];
    }

    public void LoadLevel(string _levelname)
    {
        m_currentlevel.SetActive(false);

        for (int l = 0; l < m_levels.Count; l++)
        {
            if (m_levels[l].name == _levelname)
            {
                m_levels[l].SetActive(true);
                m_currentlevel = m_levels[l];
            }
        }
    }
}

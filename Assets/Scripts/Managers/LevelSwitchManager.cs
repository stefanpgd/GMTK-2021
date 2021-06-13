using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using SilverRogue.Tools;

public class LevelSwitchManager : MonoBehaviour
{
    public static LevelSwitchManager Instance;

    [SerializeField] private GameObject player;
    [SerializeField] List<GameObject> m_levels;
    [SerializeField] private Animator shopAnimator;

    private Transform bodyTransform;
    private Transform soulTransform;
    private Animator playerAnimator;

    GameObject m_currentlevel;

    private string nextLevelToLoad;
    private Timer waitForAnimation;

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

        bodyTransform = GameObject.FindGameObjectWithTag("Body").transform;
        soulTransform = GameObject.FindGameObjectWithTag("Soul").transform;

        playerAnimator = player.GetComponent<Animator>();
    }

    public void LevelFinished(string nextLevel)
    {
        nextLevelToLoad = nextLevel;

        waitForAnimation = new Timer(1.5f);
        waitForAnimation.timerExpiredEvent += PlayShopAnimation;
    }

    private void PlayShopAnimation()
    {
        player.SetActive(false);
        shopAnimator.SetTrigger("open");
    }

    // Shop Manager calls the 'LoadNextLevel' whenever the Exit Button is pressed
    public void LoadNextLevel()
    {
        m_currentlevel.SetActive(false);
        shopAnimator.SetTrigger("close");

        player.SetActive(true);
        bodyTransform.transform.position = Vector3.zero;
        bodyTransform.transform.rotation = Quaternion.Euler(Vector3.zero);
        bodyTransform.transform.localScale = Vector3.one;

        soulTransform.transform.position = Vector3.zero;
        soulTransform.transform.rotation = Quaternion.Euler(Vector3.zero);
        soulTransform.transform.localScale = Vector3.one;
        playerAnimator.enabled = false;

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

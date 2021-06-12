using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchManager : MonoBehaviour
{
    public static LevelSwitchManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    /// <summary>
    /// Load de megegeven scene
    /// </summary>
    /// <param name="_levelname">Het level dat je wilt laden. Zorg dat deze in de build setting zit!</param>
    public void LoadLevel(string _levelname)
    {
        SceneManager.LoadScene(_levelname);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    private List<AI> enemies = new List<AI>();

    #region Singleton
    public static AIManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public void AddEnemy(AI enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(AI enemy)
    {
        enemies.Remove(enemy);
    }

    public bool AreAllEnemiesDeath()
    {
        int count = 0;

        foreach(AI enemy in enemies)
        {
            count++;
        }

        if(count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

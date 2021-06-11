using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private List<Trap> traps;

    #region Singleton
    public static PuzzleManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Instance = this;
        }
    }
    #endregion

    public void AddTrap(Trap trap) => traps.Add(trap);

    public bool AreAllTrapsCompleted()
    {
        bool areAllTrapsCompleted = true;

        foreach(Trap trap in traps)
        {
            if(!trap.TrapCompleted())
            {
                areAllTrapsCompleted = false;
            }
        }

        return areAllTrapsCompleted;
    }
}
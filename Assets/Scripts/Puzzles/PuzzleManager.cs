using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private List<Puzzle> puzzles;

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

    public void AddTrap(Puzzle puzzle) => puzzles.Add(puzzle);

    public bool AreAllPuzzlesCompleted()
    {
        bool areAllTrapsCompleted = true;

        foreach(Puzzle puzzle in puzzles)
        {
            if(!puzzle.IsPuzzleCompleted())
            {
                areAllTrapsCompleted = false;
            }
        }

        return areAllTrapsCompleted;
    }
}
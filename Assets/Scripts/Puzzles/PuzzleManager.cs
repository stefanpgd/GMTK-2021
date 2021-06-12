using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private List<Puzzle> puzzles = new List<Puzzle>();

    #region Singleton
    public static PuzzleManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion
    
    public void AddPuzzle(Puzzle puzzle) => puzzles.Add(puzzle);

    public void RemovePuzzle(Puzzle puzzle) => puzzles.Remove(puzzle);

    public bool AreAllPuzzlesCompleted()
    {
        if(puzzles.Count > 0)
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
        else
        {
            return false;
            // Safety thingy, since each level has puzzles, and puzzles add themselves it safe to assume 
            // I added this check to prevent that in the first frame of the game 'all puzzles are completed'
        }
    }
}
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private PuzzleManager puzzleManager;

    private bool doorIsOpen = false;

    private void Start()
    {
        puzzleManager = PuzzleManager.Instance;
    }

    private void Update()
    {
        // Check if Puzzles are done and if enemies are dead

        if(!doorIsOpen)
        {
            if(puzzleManager.AreAllTrapsCompleted() /* and all enemies are dead */)
            {
                doorIsOpen = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // check both for soul and body.... in future

        if(other.CompareTag(GameTags.PLAYER))
        {
            // go to next scene/level
        }
    }
}

using TMPro;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stateText;
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
            stateText.text = "Exit Door Closed";

            if(puzzleManager.AreAllPuzzlesCompleted() /* and all enemies are dead */)
            {
                doorIsOpen = true;
            }
        }
        else
        {
            stateText.text = "Exit Door Open";
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

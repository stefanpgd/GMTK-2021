using TMPro;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private TextMeshPro stateText;
    [SerializeField] string levelToSwitchTo;
    private PuzzleManager puzzleManager;

    private bool doorIsOpen = false;
    private bool bodyIsOnDoor = false;
    private bool soulIsOnDoor = false;

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

            if(bodyIsOnDoor && soulIsOnDoor)
            {
                Debug.Log("Level Completed, go to next level");
                LevelSwitchManager.Instance.LoadLevel(levelToSwitchTo);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(doorIsOpen)
        {
            if(other.CompareTag(GameTags.BODY))
            {
                bodyIsOnDoor = true;
            }

            if(other.CompareTag(GameTags.SOUL))
            {
                soulIsOnDoor = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(doorIsOpen)
        {
            if(other.CompareTag(GameTags.BODY))
            {
                bodyIsOnDoor = false;
            }

            if(other.CompareTag(GameTags.SOUL))
            {
                soulIsOnDoor = false;
            }
        }
    }
}

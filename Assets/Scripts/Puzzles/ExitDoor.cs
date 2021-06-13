using TMPro;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private TextMeshPro stateText;
    [SerializeField] string levelToSwitchTo;
    [SerializeField] private Animator playerEndAnimator;

    [SerializeField] private SpriteRenderer m_Door;
    [SerializeField] private Sprite m_Closed, m_Open;

    private PuzzleManager puzzleManager;
    private AIManager aiManager;

    private bool doorIsOpen = false;
    private bool bodyIsOnDoor = false;
    private bool soulIsOnDoor = false;
    private bool doorIsUsed = false;

    private void Start()
    {
        puzzleManager = PuzzleManager.Instance;
        aiManager = AIManager.Instance;
    }

    private void Update()
    {
        // Check if Puzzles are done and if enemies are dead
        if(!doorIsOpen)
        {
            stateText.text = "Exit Door Closed";
            m_Door.sprite = m_Closed;

            if (puzzleManager.AreAllPuzzlesCompleted() && aiManager.AreAllEnemiesDeath())
            {
                doorIsOpen = true;
            }
        }
        else
        {
            if(!doorIsUsed)
            {
                stateText.text = "Exit Door Open";
                m_Door.sprite = m_Open;

                if(bodyIsOnDoor && soulIsOnDoor)
                {
                    playerEndAnimator.enabled = true;
                    Debug.Log("Level Completed, go to next level");
                    LevelSwitchManager.Instance.LevelFinished(levelToSwitchTo);
                    doorIsUsed = true;
                }
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

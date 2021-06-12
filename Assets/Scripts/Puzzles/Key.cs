using SilverRogue.Tools;
using UnityEngine;

public class Key : Puzzle
{
    [SerializeField] private bool PickedUpByBody;
    [SerializeField] private GameObject keyContent;
    [SerializeField] private CollisionEvents keyCollisionEvents;

    private PuzzleManager puzzleManager;
    private bool keyPickedUp;

    private void Start()
    {
        puzzleManager = PuzzleManager.Instance;
        puzzleManager.AddPuzzle(this);
        keyCollisionEvents.OnTriggerEnterEvent += OnKeyEnter;
    }

    private void OnDestroy()
    {
        puzzleManager.RemovePuzzle(this);
        keyCollisionEvents.OnTriggerEnterEvent -= OnKeyEnter;
    }

    private void OnKeyEnter(Collider other)
    {
        if(!keyPickedUp)
        {
            if(PickedUpByBody)
            {
                if(other.CompareTag(GameTags.BODY))
                {
                    keyPickedUp = true;
                    keyContent.SetActive(false);
                }
            }
            else
            {
                if(other.CompareTag(GameTags.SOUL))
                {
                    keyPickedUp = true;
                    keyContent.SetActive(false);
                }
            }
        }
    }

    public override bool IsPuzzleCompleted()
    {
        return keyPickedUp;
    }
}

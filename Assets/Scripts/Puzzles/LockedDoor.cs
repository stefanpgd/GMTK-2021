using SilverRogue.Tools;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Puzzle
{
    [SerializeField] private List<Key> keysRequiredToOpenDoor;
    [SerializeField] private CollisionEvents doorCollisionEvents;
    [SerializeField] private GameObject doorClosedContent;
    [SerializeField] private GameObject doorOpenContent;

    private PuzzleManager puzzleManager;
    private bool doorIsOpen = false;

    private void Start()
    {
        puzzleManager = PuzzleManager.Instance;
        puzzleManager.AddPuzzle(this);

        doorClosedContent.SetActive(true);
        doorOpenContent.SetActive(false);

        doorCollisionEvents.OnTriggerEnterEvent += OnDoorTriggerEnter;
    }

    private void OnDisable()
    {
        puzzleManager.RemovePuzzle(this);
        doorCollisionEvents.OnTriggerEnterEvent -= OnDoorTriggerEnter;
    }

    private void OnDoorTriggerEnter(Collider other)
    {
        if(other.CompareTag(GameTags.BODY) || other.CompareTag(GameTags.SOUL))
        {
            bool areAllKeysCollected = true;

            foreach(Key key in keysRequiredToOpenDoor)
            {
                if(!key.IsPuzzleCompleted())
                {
                    areAllKeysCollected = false;
                }
            }

            if(areAllKeysCollected)
            {
                doorIsOpen = true;
                doorClosedContent.SetActive(false);
                doorOpenContent.SetActive(true);
            }
        }
    }

    public override bool IsPuzzleCompleted()
    {
        return doorIsOpen;
    }
}

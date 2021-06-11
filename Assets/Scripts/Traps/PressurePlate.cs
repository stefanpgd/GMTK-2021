using UnityEngine;

public class PressurePlate : Trap
{
    private PuzzleManager puzzleManager;

    private bool IsPressedByPlayer;

    private void Start()
    {
        puzzleManager = PuzzleManager.Instance;

        puzzleManager.AddTrap(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(GameTags.PLAYER))
        {
            IsPressedByPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(GameTags.PLAYER))
        {
            IsPressedByPlayer = false;
        }
    }

    public override bool TrapCompleted()
    {
        return IsPressedByPlayer;
    }
}
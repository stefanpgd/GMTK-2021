using UnityEngine;

public class PressurePlate : Puzzle
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material puzzleNotCompleted;
    [SerializeField] private Material puzzleCompleted;

    private PuzzleManager puzzleManager;
    private bool IsPressedByPlayer;

    private void Start()
    {
        puzzleManager = PuzzleManager.Instance;

        puzzleManager.AddTrap(this);

        meshRenderer.material = puzzleNotCompleted;
    }

    private void OnTriggerEnter(Collider other)
    {
        // update fancy sprite
        if(other.CompareTag(GameTags.BODY) || other.CompareTag(GameTags.SOUL))
        {
            meshRenderer.material = puzzleCompleted;
            IsPressedByPlayer = true;
        }
    }

    public override bool IsPuzzleCompleted()
    {
        return IsPressedByPlayer;
    }
}
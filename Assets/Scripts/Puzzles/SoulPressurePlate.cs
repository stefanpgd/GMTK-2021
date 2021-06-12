using UnityEngine;

public class SoulPressurePlate : Puzzle
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material puzzleNotCompleted;
    [SerializeField] private Material puzzleCompleted;

    private PuzzleManager puzzleManager;
    private bool IsPressedByPlayer;

    private void Start()
    {
        puzzleManager = PuzzleManager.Instance;
        puzzleManager.AddPuzzle(this);

        meshRenderer.material = puzzleNotCompleted;
    }

    private void OnDisable()
    {
        puzzleManager.RemovePuzzle(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(GameTags.SOUL))
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

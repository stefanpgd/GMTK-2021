using UnityEngine;

public class BodyPressurePlate : Puzzle
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite puzzleNotCompleted;
    [SerializeField] private Sprite puzzleCompleted;

    private PuzzleManager puzzleManager;
    private bool IsPressedByPlayer;

    private void Start()
    {
        puzzleManager = PuzzleManager.Instance;
        puzzleManager.AddPuzzle(this);

        spriteRenderer.sprite = puzzleNotCompleted;
    }

    private void OnDisable()
    {
        if(puzzleManager != null)
        {
            puzzleManager.RemovePuzzle(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(GameTags.BODY))
        {
            spriteRenderer.sprite = puzzleCompleted;
            IsPressedByPlayer = true;
        }
    }

    public override bool IsPuzzleCompleted()
    {
        return IsPressedByPlayer;
    }
}

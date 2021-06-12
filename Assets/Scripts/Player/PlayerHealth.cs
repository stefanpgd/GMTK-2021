using UnityEngine;
using SilverRogue.Tools;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public Action playerDiedEvent;
    public Action playerHealthUpdatedEvent;

    [SerializeField] private CollisionEvents bodyCollider;
    [SerializeField] private CollisionEvents soulCollider;

    #region Singleton
    public static PlayerHealth Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    private void Start()
    {
        MaxHealth = GameVariables.START_MAX_HEALTH;
        Health = MaxHealth;
    }

    private void UpdateHealth(int value)
    {
        Health += value;

        DidPlayerDie();

        playerHealthUpdatedEvent.Invoke();
    }

    private void DidPlayerDie()
    {
        if(Health < 0)
        {
            playerDiedEvent.Invoke();
            Debug.Log("AAA kut ik ben dood");
        }
    }

    private void OnSoulCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(GameTags.ENEMY))
        {
            UpdateHealth(GameVariables.ENEMY_DAMAGE);
        }
    }

    private void OnBodyCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(GameTags.ENEMY))
        {
            UpdateHealth(GameVariables.ENEMY_DAMAGE);
        }
    }
}

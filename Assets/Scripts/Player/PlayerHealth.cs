using UnityEngine;
using SilverRogue.Tools;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public Action playerDiedEvent = delegate { };
    public Action playerHealthUpdatedEvent = delegate { };

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

        bodyCollider.OnTriggerEnterEvent += OnBodyTriggerEnter;
        soulCollider.OnTriggerEnterEvent += OnSoulTriggerEnter;
    }

    private void OnDestroy()
    {
        bodyCollider.OnTriggerEnterEvent -= OnBodyTriggerEnter;
        soulCollider.OnTriggerEnterEvent -= OnSoulTriggerEnter;
    }

    public void UpdateHealth(int value)
    {
        Health += value;

        DidPlayerDie();

        playerHealthUpdatedEvent.Invoke();

        Debug.Log("Current Player Health: " + Health);
    }

    // ik ben te lui om het netjes nog te doen
    public void UpdateMaxHealth(int value)
    {
        MaxHealth += value;

        playerHealthUpdatedEvent.Invoke();
    }

    private void DidPlayerDie()
    {
        if(Health < 0)
        {
            Health = 0;
            Debug.Log("Player died!!");
            playerDiedEvent.Invoke();
        }
    }

    private void OnBodyTriggerEnter(Collider other)
    {
        if(other.CompareTag(GameTags.ENEMY))
        {
            UpdateHealth(-GameVariables.ENEMY_DAMAGE);
        }
    }

    private void OnSoulTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(GameTags.ENEMY))
        {
            UpdateHealth(-GameVariables.ENEMY_DAMAGE);
        }
    }
}

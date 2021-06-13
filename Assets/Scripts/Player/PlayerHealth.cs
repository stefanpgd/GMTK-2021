using UnityEngine;
using SilverRogue.Tools;
using System;
using SilverRogue.CameraControl;

public class PlayerHealth : MonoBehaviour
{
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public Action playerDiedEvent = delegate { };
    public Action playerHealthUpdatedEvent = delegate { };

    [SerializeField] private CollisionEvents bodyCollider;
    [SerializeField] private CollisionEvents soulCollider;
    [SerializeField] private float screenshakeDuration;
    [SerializeField] private float screenshakeStrength;

    private CameraShake cameraShake;

    public float invincibilityTimer;
    private Timer invincibility;
    private bool canTakeDamage;

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
        invincibility = new Timer(invincibilityTimer);

        MaxHealth = GameVariables.START_MAX_HEALTH;
        Health = MaxHealth;

        bodyCollider.OnTriggerEnterEvent += OnBodyTriggerEnter;
        soulCollider.OnTriggerEnterEvent += OnSoulTriggerEnter;
    }

    private void Update()
    {
        if(invincibility.Expired)
        {
            canTakeDamage = true;
        }
    }

    private void OnDestroy()
    {
        bodyCollider.OnTriggerEnterEvent -= OnBodyTriggerEnter;
        soulCollider.OnTriggerEnterEvent -= OnSoulTriggerEnter;
    }

    public void UpdateHealth(int value)
    {
        if(canTakeDamage)
        {
            Health += value;

            if(value < 0)
            {
                cameraShake.ScreenShake(screenshakeDuration, screenshakeStrength);
            }

            DidPlayerDie();

            playerHealthUpdatedEvent.Invoke();

            Debug.Log("Current Player Health: " + Health);

            canTakeDamage = false;
            invincibility.Restart();
        }
    }

    // ik ben te lui om het netjes nog te doen
    public void UpdateMaxHealth(int value)
    {
        MaxHealth += value;

        playerHealthUpdatedEvent.Invoke();
    }

    private void DidPlayerDie()
    {
        if(Health <= 0)
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

        if(other.CompareTag(GameTags.PROJECTILE))
        {
            UpdateHealth(-GameVariables.SELF_DAMAGE);
        }

        if(other.CompareTag(GameTags.ENEMY_PROJECTILE))
        {
            UpdateHealth(-GameVariables.ENEMY_PROJECTILE_DAMAGE);
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

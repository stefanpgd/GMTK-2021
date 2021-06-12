using SilverRogue.Tools;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private float attackCooldownTime;
    [SerializeField] private AudioSource m_Slash;

    [SerializeField] private GameObject m_SlashEffect;
    [SerializeField] private Transform m_SlashEmitter;

    private Timer attackCooldown;   // the (cooldown) time between slashes   

    private void Start()
    {
        attackCooldown = new Timer(attackCooldownTime);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(attackCooldown.Expired)
            {
                Attack();

                m_Slash.Play();
                GameObject effect = Instantiate(m_SlashEffect, m_SlashEmitter.position, m_SlashEmitter.rotation);
                Destroy(effect, 1f);
            }
        }
    }

    private void Attack()
    {
        weaponAnimator.SetTrigger("Attack");
        attackCooldown.Restart();
    }
}

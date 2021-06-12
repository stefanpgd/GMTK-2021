using SilverRogue.Tools;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private float attackCooldownTime;

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
            }
        }
    }

    private void Attack()
    {
        weaponAnimator.SetTrigger("Attack");
        attackCooldown.Restart();
    }
}

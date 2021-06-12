using SilverRogue.Tools;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private AudioSource m_Shoot;

    private Timer shootDelay;

    private void Start()
    {
        shootDelay = new Timer(timeBetweenShots);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(shootDelay.Expired)
            {
                FireProjectile();
                m_Shoot.Play();
            }
        }
    }

    private void FireProjectile()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        shootDelay.Restart();
    }
}

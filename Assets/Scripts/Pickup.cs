using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int HealAmount;

    public enum Pickups {HealthPickup}
    public Pickups pickup;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Body")
        {
            switch (pickup)
            {
                case (Pickups.HealthPickup):
                    PlayerHealth.Instance.UpdateHealthPickup(HealAmount);
                    Debug.Log("wajow?");
                    Destroy(gameObject);
                    break;
            }
        }
    }
}

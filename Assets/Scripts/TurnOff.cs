using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    [SerializeField] private GameObject m_Player;

    public void ByePlayer()
    {
        m_Player.SetActive(false);
    }
}

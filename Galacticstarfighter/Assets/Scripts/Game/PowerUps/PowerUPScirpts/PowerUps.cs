using UnityEngine;
using System.Collections;

public abstract class PowerUps : MonoBehaviour 
{
    public GameData m_GData;
    public PlayerData m_PData;

    public bool m_IsStorable;

    public float m_DropSpeed = -2.0f;
    public abstract void Start();
    public abstract void Update();
    public abstract void ItemAffect(GameObject player);
    public abstract void UseItem(GameObject player);

}

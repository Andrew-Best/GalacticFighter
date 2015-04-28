using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    public Ship m_Ship;
    public ShipController m_ShipController;
    public ShipData m_ShipData;
    public GameObject m_Target;

    public abstract void Awake();
    public abstract void OnExit();
    public abstract void Update();
    public abstract void SetProjectiles();
    
}

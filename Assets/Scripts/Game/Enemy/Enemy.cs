using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    #region Variables
    public Ship m_Ship;
    public ShipController m_ShipController;
    public ShipData m_ShipData;
    public GameObject m_Target;
    #endregion

    public abstract void Awake();
    public abstract void OnExit();
    public abstract void Update();
    public abstract void SetProjectiles();
    
}

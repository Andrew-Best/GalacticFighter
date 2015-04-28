using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public ShipData m_SData;
    public ShieldData m_ShieldData;

    public int m_DamageModifier;
    public int m_Level;

    public int m_EngineLevel;
    public int m_DamageLevel;
    public int m_HealthLevel;
    public int m_ShieldLevel;
}
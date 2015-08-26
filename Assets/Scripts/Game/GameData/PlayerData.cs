using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public static PlayerData m_PData;

    public List<String> m_Items;
    public List<String> m_Tokens;

    public int m_EnemiesKilledLifetime;
    public int m_TotalScore;
    public int m_WavesCompleted;
    public int m_Salvage;
    public int m_ShipLevel;
    public int m_EngineLevel;
    public int m_DamageLevel;
    public int m_HealthLevel;
    public int m_ShieldLevel;
    public int m_TempShieldLevel;

    public bool m_HasShield;

    public int m_HP;
    public int m_Shield;
    public int m_DamageModifer;
    public int m_EngineModifier;

    // Use this for initialization
    void Awake()
    {
        if (m_PData == null)
        {
            DontDestroyOnLoad(gameObject);
            m_PData = this;
        }
        else if(m_PData != null)
        {
            Destroy(gameObject);
        }

        m_EnemiesKilledLifetime = 0;
        m_TotalScore = 0;
        m_WavesCompleted = 0;
        m_Salvage = 0;
        m_ShipLevel = 1;
        m_EngineLevel = 1;
        m_DamageLevel = 1;
        m_HealthLevel = 1;
        m_ShieldLevel = 0;
        m_TempShieldLevel = 1;

        if(m_ShieldLevel == 0)
        {
            m_HasShield = false;
        }
        else
        {
            m_HasShield = true;
        }

        if (m_HasShield)
        {
            m_Shield = 10 * (m_ShipLevel * m_ShieldLevel);
        }
   

        m_HP = 20 * m_ShipLevel * m_HealthLevel;
        m_DamageModifer = 1 * (m_ShipLevel * m_DamageLevel);
        m_EngineModifier = 1 * (m_ShipLevel * m_EngineLevel);
    }
}

[System.Serializable]
class PlayerSave
{
    public int m_EnemiesKilledLifetime;
    public int m_TotalScore;
    public int m_WavesCompleted;
    public int m_Salvage;
    public int m_ShipTier;
    public int m_EngineLevel;
    public int m_DamageLevel;
    public int m_HealthLevel;
    public int m_ShieldLevel;

    public int m_HP;
    public int m_Shield;

    public List<String> m_Items;
    public List<String> m_Tokens;
}
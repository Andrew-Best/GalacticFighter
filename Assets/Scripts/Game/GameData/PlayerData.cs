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
    #region Variables
    /// <summary>Player Data</summary>
    public static PlayerData m_PData;

    /// <summary>List of Items - strings</summary>
    public List<String> m_Items;
    /// <summary>List of Tokens - strings</summary>
    public List<String> m_Tokens;

    /// <summary>Number of Enemies killed</summary>
    public int m_EnemiesKilled;
    /// <summary>Player's total score</summary>
    public int m_TotalScore;
    /// <summary>Number of waves completed</summary>
    public int m_WavesCompleted;
    /// <summary>Amount of Salvage the player has</summary>
    public int m_Salvage;
    /// <summary>Level of the Player's ship</summary>
    public int m_ShipLevel;
    /// <summary>Level of the Player's ship engine</summary>
    public int m_EngineLevel;
    /// <summary>Level of the Player's ship damage</summary>
    public int m_DamageLevel;
    /// <summary>Level of the Player's ship health</summary>
    public int m_HealthLevel;
    /// <summary>Level of the Player's ship shield</summary>
    public int m_ShieldLevel;
    /// <summary>Level of the Player's ship temp shield</summary>
    public int m_TempShieldLevel;

    /// <summary>Whether the player has a shield or not</summary>
    public bool m_HasShield;

    public int m_HP;
    public int m_Shield;
    public int m_DamageModifer;
    public int m_EngineModifier;
    #endregion

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

        m_EnemiesKilled = 0;
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
    /// <summary>Enemies the player has killed total - SAVE FILE</summary>
    public int m_EnemiesKilledLifetime;
    /// <summary>Player's total score - SAVE FILE</summary>
    public int m_TotalScore;
    /// <summary>Number of waves the player has completed - SAVE FILE</summary>
    public int m_WavesCompleted;
    /// <summary>Amount of salvage the player has - SAVE FILE</summary>
    public int m_Salvage;
    /// <summary>Level of the player's ship - SAVE FILE</summary>
    public int m_ShipTier;
    /// <summary>Level of the player's ship engine - SAVE FILE</summary>
    public int m_EngineLevel;
    /// <summary>Level of the player's ship damage - SAVE FILE</summary>
    public int m_DamageLevel;
    /// <summary>Level of the player's ship health - SAVE FILE</summary>
    public int m_HealthLevel;
    /// <summary>Level of the player's ship shield - SAVE FILE</summary>
    public int m_ShieldLevel;

    /// <summary>Amount of HP the ship has - SAVE FILE</summary>
    public int m_HP;
    /// <summary>Amount of shield the ship has - SAVE FILE</summary>
    public int m_Shield;

    /// <summary>List of items the player has - string - SAVE FILE</summary>
    public List<String> m_Items;
    /// <summary>List of tokens the player has - string - SAVE FILE</summary>
    public List<String> m_Tokens;
}
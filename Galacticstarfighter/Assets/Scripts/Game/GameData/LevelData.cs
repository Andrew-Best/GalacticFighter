using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelData : MonoBehaviour 
{
    public GameData m_GData;

    public int m_CurrLevel;

    public int m_Tier;

    public void SetLevelData(int level/*, int tier*/)
    {
        m_GData.m_Level = level;
        //m_GData.m_Tier = tier;
    }

    public void LoadLevelData()
    {
        m_CurrLevel = m_GData.m_Level;
        m_Tier = m_GData.m_EnemyTier;
    }
}

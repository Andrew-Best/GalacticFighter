﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelData : MonoBehaviour
{
    #region Variables
    public GameData m_GData;
    public List<Level> m_Levels = new List<Level>();


    public int m_CurrLevel;

    public int m_Tier;
    #endregion

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
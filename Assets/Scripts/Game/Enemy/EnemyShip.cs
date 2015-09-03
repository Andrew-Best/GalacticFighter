using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShip : Ship
{
    /// <summary>Tier of the ship</summary>
    public int m_Tier;
    /// <summary>Amount of salvage this kill is worth</summary>
    public int m_SalvageVal;
    /// <summary>Amount of score this kill is worth</summary>
    public int m_ScoreVal;

    /// <summary>Game Data script</summary>
    public GameData m_GData;
    /// <summary>Item to drop on death</summary>
    public LootTable m_ItemToDrop;
    /// <summary>Random number chosen by RNG</summary>
    private int randNum_;

    public int InventorySize
    {
        get
        {
            return (Constants.BASE_ENEMY_INVO_SIZE * (m_Level * m_Tier));
        }
    }

    public void Awake()
    {
        SetStats();
    }

    /// <summary>Set the stats of the enemy ship</summary>
    public void SetStats()
    {
        m_Level = m_GData.m_Level;
        m_Tier = m_GData.m_EnemyTier;

        m_SData.m_HP = 2 * (m_Level * m_Tier);
        m_DamageModifier = m_DamageLevel * Constants.DEFAULT_UPGRADE_MODIFIER;

        m_EngineLevel = m_GData.m_EnemyEngineLevel * (m_Level * m_Tier);
        m_DamageLevel = m_GData.m_EnemyDamageLevel * (m_Level * m_Tier);
        m_HealthLevel = m_GData.m_EnemyHealthLevel * (m_Level * m_Tier);
        m_ShieldLevel = m_GData.m_EnemyShieldLevel * (m_Level * m_Tier - 1);
        m_SalvageVal = 50 * m_Level * m_Tier;
        m_ScoreVal = m_SalvageVal * 2;

        if(m_ShieldLevel == 0)
        {
            m_SData.m_HasShield = false;
            m_ShieldData.SetShield(this.gameObject);
        }
        else
        {
            m_SData.m_HasShield = true;
            m_SData.m_CurrShield = 5 * (m_Level * m_Tier);
            m_ShieldData.SetShield(this.gameObject);
        }

    }

    /// <summary>Determine what item the enemy should drop</summary>
    public void DropLootEnemy(GameObject ship)
    {
        randNum_ = Random.Range(0, 100);

        if (randNum_ < 20)
        {
            m_ItemToDrop.LootDrop(ship);
        }
        else
        {
            return;
        }
    }

    /// <summary>Determine what item the boss should drop</summary>
    public void DropLootBoss(GameObject ship)
    {
        randNum_ = Random.Range(0, 100);

        ship.GetComponent<BossShip>().BossLootDrop(ship);

        if (randNum_ < 20)
        {
            m_ItemToDrop.LootDrop(ship);
        }
        else
        {
            return;
        }
    }

    /// <summary>Determine what item the miniboss should drop</summary>
    public void DropLootMiniBoss(GameObject ship)
    {
        randNum_ = Random.Range(0, 100);

        ship.GetComponent<MiniBossShip>().BossLootDrop(ship);

        if (randNum_ < 20)
        {
            m_ItemToDrop.LootDrop(ship);
        }
        else
        {
            return;
        }
    }

}
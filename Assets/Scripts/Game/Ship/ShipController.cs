﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    #region Variables
    /// <summary>Ship Data that belongs to this controller</summary>
    public ShipData m_Data;
    /// <summary>Ship that belongs to this controller</summary>
    public Ship m_Ship;

    /// <summary>Explosion when the ship dies</summary>
    public GameObject m_Explosion;

    /// <summary>Damage after the damage modifier is applied</summary>
    private int totalDamage_;
    #endregion

    /// <summary>Fire the weapons of the ship</summary>
    /// <param name="firedBy">The name of the ship that is firing</param>
    public void FireWeapons(string firedBy)
    {
        for (int i = 0; i < m_Data.m_WeaponState.Length; ++i)
        {
            if(m_Data.m_WeaponState[i].m_Ammo > 0)
            {
                if (m_Data.m_WeaponState[i].m_CooldownTimer <= 0.0f)
                {
                    m_Data.m_Weapons[i].Fire(m_Data.m_WeaponState[i], gameObject, firedBy);
                }
            }
        }
    }

    /// <summary>Damage received by the ship</summary>
    /// <param name="ship">Ship taking the damage</param>
    /// <param name="damage">Amount of damage being dealt</param>
    public void ApplyDamage(GameObject ship, int damage)
    {
        totalDamage_ = damage * ship.GetComponent<Ship>().m_DamageModifier;

        //if player ship
        if(ship.tag == "Player")
        {
            if(ship.GetComponent<PlayerShip>().m_HasTempShield)
            {
                m_Data.m_CurrShield -= totalDamage_;
                if (m_Data.m_CurrShield <= 0)
                {
                    ship.GetComponent<PlayerShip>().m_HasTempShield = false;
                    ship.GetComponent<Ship>().m_ShieldData.SetShield(ship);
                }
            }
            else if(m_Data.m_HasShield)
            {
                m_Data.m_CurrShield -= totalDamage_;
                if (m_Data.m_CurrShield <= 0)
                {
                    m_Data.m_HasShield = false;
                    ship.GetComponent<Ship>().m_ShieldData.SetShield(ship);
                }
            }
            else
            {
                m_Data.m_HP -= totalDamage_;
            }
        }

        //if enemy
        if (ship.tag != "Player")
        {
            if (m_Data.m_HasShield)
            {
                m_Data.m_CurrShield -= totalDamage_;
                if (m_Data.m_CurrShield <= 0)
                {
                    m_Data.m_HasShield = false;
                    ship.GetComponent<Ship>().m_ShieldData.SetShield(ship);
                }
            }
            else
            {
                m_Data.m_HP -= totalDamage_;
            }
        }

        if (m_Data.m_HP <= 0)
        {
            if (ship.tag == "Player")
            {
                ship.GetComponent<PlayerController>().enabled = false;//disable player
                Camera.main.GetComponent<GameController>().EnableRestart();
                ship.SetActive(false);
            }

            if (ship.tag == "Enemy")
            {
                Camera.main.GetComponent<Waves>().m_EnemyCount--;
                Camera.main.GetComponent<EnemySpawn>().m_RequiredKills -= 1;
                Camera.main.GetComponent<EnemySpawn>().m_ReqKillText.text = Camera.main.GetComponent<EnemySpawn>().m_RequiredKills.ToString();
                Camera.main.GetComponent<GameController>().m_Score += ship.GetComponent<EnemyShip>().m_ScoreVal * (ship.GetComponent<EnemyShip>().m_Level *
                                                                                                                  ship.GetComponent<EnemyShip>().m_Tier);
                Camera.main.GetComponent<GameController>().m_Salvage += ship.GetComponent<EnemyShip>().m_SalvageVal;
                ship.GetComponent<EnemyShip>().DropLootEnemy(ship);
                ship.SetActive(false);
            }
            if (ship.tag == "MiniBoss")
            {
                Camera.main.GetComponent<GameController>().m_Score += ship.GetComponent<MiniBossShip>().m_ScoreVal;
                Camera.main.GetComponent<GameController>().m_Salvage += ship.GetComponent<MiniBossShip>().m_SalvageVal;
                ship.GetComponent<EnemyShip>().DropLootMiniBoss(ship);
                ship.SetActive(false);
            }
            if (ship.tag == "Boss")
            {
                Camera.main.GetComponent<GameController>().m_Score += ship.GetComponent<BossShip>().m_ScoreVal;
                Camera.main.GetComponent<GameController>().m_Salvage += ship.GetComponent<BossShip>().m_SalvageVal;
                ship.GetComponent<EnemyShip>().DropLootBoss(ship);
                ship.SetActive(false);
            }
            Instantiate(m_Explosion, transform.position, transform.rotation);
        }
    }
}

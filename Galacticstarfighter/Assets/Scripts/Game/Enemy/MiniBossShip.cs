using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MiniBossShip : EnemyShip
{
    public List<GameObject> m_BossDrops;

    private int randDrop_;

    new public void Awake()
    {
        SetMiniBossStats();
    }

    public void SetMiniBossStats()
    {
        m_Level = m_GData.m_Level;
        m_Tier = m_GData.m_EnemyTier;

        m_SData.m_HasShield = true;

        m_ShieldData.SetShield(Camera.main.GetComponent<EnemySpawn>().m_BossObj);

        m_SData.m_HP = 10 * m_Level * m_Tier;
        m_SData.m_CurrShield = 10 * m_Level * m_Tier;
        m_DamageModifier = m_DamageLevel * Constants.DEFAULT_UPGRADE_MODIFIER;

        m_EngineLevel = m_GData.m_EnemyEngineLevel * (m_Level * m_Tier);
        m_DamageLevel = m_GData.m_EnemyDamageLevel * (m_Level * m_Tier);
        m_HealthLevel = m_GData.m_EnemyHealthLevel * (m_Level * m_Tier);
        m_ShieldLevel = m_GData.m_EnemyShieldLevel * (m_Level * m_Tier);
        m_SalvageVal = 250 * (m_Level * m_Tier);
        m_ScoreVal = m_SalvageVal * 2;
    }

    public void SetDrops(GameObject parentShip)
    {
        randDrop_ = Random.Range(0, 101);
 
        Vector3 spawnPosition = new Vector3(parentShip.transform.position.x, parentShip.transform.position.y, 0);
        Quaternion spawnRotation = Quaternion.identity;

        if (randDrop_ <= 25)
        {
            //spawn health token
            Instantiate(m_BossDrops[0], spawnPosition, spawnRotation);
        }
        else if (randDrop_ > 25 && randDrop_ <= 50)
        {
            //spawn shield token
            Instantiate(m_BossDrops[1], spawnPosition, spawnRotation);
        }
        else if (randDrop_ > 50 && randDrop_ <= 75)
        {
            //spawn weapons token
            Instantiate(m_BossDrops[2], spawnPosition, spawnRotation);
        }
        else
        {
            //spawn engines token
            Instantiate(m_BossDrops[3], spawnPosition, spawnRotation);
        }
    }

    public void BossLootDrop(GameObject parentShip)
    {
        //foreach (Weapon weapon in this.GetComponent<ShipData>().m_Weapons)
        //{
            for (int i = 0; i < this.GetComponent<ShipData>().m_Weapons.Length; ++i)
            {
                this.GetComponentInChildren<Weapon>().m_MaxAmmo = 1000;
                this.GetComponentInChildren<Weapon>().SetProjectile(this.GetComponentInChildren<Weapon>().m_ProjectilePrefabs[0]);
                this.GetComponent<ShipData>().m_WeaponState[i].m_Ammo = this.GetComponentInChildren<Weapon>().m_MaxAmmo;
            }
        //}
    }
}

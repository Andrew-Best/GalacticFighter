using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPlayer : MonoBehaviour 
{
    public GameData m_GData;
    public PlayerData m_PData;
    public GameController m_GController;

    public List<GameObject> m_PlayerPrefab = new List<GameObject>();
    private List<GameObject> playerPool_ = new List<GameObject>();

    public GameObject m_Player;
    private GameObject playerObj_;

    public void SetStats(GameObject player)
    {
        m_Player.GetComponent<PlayerShip>().m_DamageModifier = m_PData.m_DamageModifer;
        m_Player.GetComponent<PlayerController>().m_Salvage = m_PData.m_Salvage;
        m_Player.GetComponent<ShipData>().m_HP = m_PData.m_HP;
        m_Player.GetComponent<ShipData>().m_HasShield = m_PData.m_HasShield;

        for (int i = 0; i < m_Player.GetComponent<ShipData>().m_Inventory.Count; ++i)
        {
            for (int j = 0; j < m_PData.m_Items.Count; ++j)
            {
                m_PData.m_Items[j] = m_Player.GetComponent<ShipData>().m_Inventory[i].name;
            }
        }
    }

    public void SetSavedStats(GameObject player)
    {
        m_Player.GetComponent<PlayerShip>().m_DamageModifier = m_PData.m_DamageModifer;
        m_Player.GetComponent<PlayerController>().m_Salvage = m_GController.m_Salvage;
        m_Player.GetComponent<ShipData>().m_HP = m_PData.m_HP;

        m_Player.GetComponent<ShipData>().m_HasShield = m_GController.m_TempHasShield;

        for (int i = 0; i < m_Player.GetComponent<ShipData>().m_Inventory.Count; ++i)
        {
            for (int j = 0; j < m_PData.m_Items.Count; ++j)
            {
                m_PData.m_Items[j] = m_Player.GetComponent<ShipData>().m_Inventory[i].name;
            }
        }
    }

    public void Spawn()
    {

        if (m_GController.m_Lives > 0)
        {
            m_GController.m_ControlText.text = "";

            for (int i = 0; i < m_GController.m_Lives; ++i)
            {
                playerObj_ = m_PlayerPrefab[m_PData.m_ShipLevel - 1];
                GameObject obj = (GameObject)Instantiate(playerObj_);
                obj.SetActive(false);
                playerPool_.Add(obj);
            }

            m_Player = playerPool_[0];
            SetStats(m_Player);

            if (m_Player.GetComponent<ShipData>().m_HasShield)
            {
                m_Player.GetComponent<ShipData>().m_CurrShield = m_PData.m_Shield;
                m_Player.GetComponent<PlayerShip>().m_ShieldData.SetShield(m_Player);
            }
            else
            {
                m_Player.GetComponent<ShipData>().m_CurrShield = 0;
                m_Player.GetComponent<PlayerShip>().m_ShieldData.SetShield(m_Player);
            }
            
            Vector3 playerSpawn = new Vector3(0.0f, -5.0f, 0.0f);
            Quaternion spawnPlayerRotation = Quaternion.identity;

            m_Player.SetActive(true);
            m_Player.transform.position = playerSpawn;
            m_Player.transform.rotation = spawnPlayerRotation;
            m_Player.GetComponentInChildren<Weapon>().SetProjectile(m_Player.GetComponentInChildren<Weapon>().m_ProjectilePrefabs[0]);

            SetProjectile();
        }
    }

    public void PlayerRespawn()
    {
        m_Player = playerPool_[0];
        SetSavedStats(m_Player);

        if (m_Player.GetComponent<ShipData>().m_HasShield)
        {
            m_Player.GetComponent<ShipData>().m_CurrShield = m_PData.m_Shield;
            m_Player.GetComponent<PlayerShip>().m_ShieldData.SetShield(m_Player);
        }
        else
        {
            m_Player.GetComponent<ShipData>().m_CurrShield = 0;
            m_Player.GetComponent<PlayerShip>().m_ShieldData.SetShield(m_Player);
        }

        Vector3 playerSpawn = new Vector3(0.0f, -5.0f, 0.0f);
        Quaternion spawnPlayerRotation = Quaternion.identity;

        m_Player.SetActive(true);
        m_Player.transform.position = playerSpawn;
        m_Player.transform.rotation = spawnPlayerRotation;
        m_Player.GetComponentInChildren<Weapon>().SetProjectile(m_Player.GetComponentInChildren<Weapon>().m_ProjectilePrefabs[0]);

        SetProjectile();
    }

    public void SetProjectile()
    {
        for (int i = 0; i < m_Player.GetComponent<ShipData>().m_Weapons.Length; ++i)
        {
            m_Player.GetComponent<ShipData>().m_WeaponState[i].m_Ammo = m_Player.GetComponentInChildren<Weapon>().m_MaxAmmo;
        }
    }
}

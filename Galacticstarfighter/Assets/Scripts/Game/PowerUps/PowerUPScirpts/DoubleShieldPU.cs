using UnityEngine;
using System.Collections;

public class DoubleShieldPU : PowerUps
{

    public override void Start()
    {
        m_IsStorable = false;
    }
    public override void Update()
    {
        if (this.isActiveAndEnabled)
        {
            Vector3 movement = new Vector3(0, m_DropSpeed, 0);

            GetComponent<Rigidbody>().velocity = movement;
        }
    }

    public override void ItemAffect(GameObject player)
    {
        //if player has shields, set health of shields to double the max
        if(player.GetComponent<ShipData>().m_HasShield)
        {
            if (player.GetComponent<ShipData>().m_HP < player.GetComponent<PlayerShip>().m_MaxHP)
            {
                player.GetComponent<ShipData>().m_HP = player.GetComponent<PlayerShip>().m_MaxHP;
            }
            player.GetComponent<ShipData>().m_CurrShield = player.GetComponent<PlayerShip>().m_MaxShieldHP * 2;
            player.GetComponent<PlayerShip>().m_ShieldData.SetShield(player);
        }
        //if player does not have shields, set shileds to true with double base hp
        else
        {
            if (player.GetComponent<ShipData>().m_HP < player.GetComponent<PlayerShip>().m_MaxHP)
            {
                player.GetComponent<ShipData>().m_HP = player.GetComponent<PlayerShip>().m_MaxHP;
            }
            player.GetComponent<PlayerShip>().m_HasTempShield = true;
            player.GetComponent<ShipData>().m_CurrShield = player.GetComponent<PlayerShip>().m_TempShieldHP * 2;
            player.GetComponent<PlayerShip>().m_ShieldData.SetShield(player);
        }
    }

    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}

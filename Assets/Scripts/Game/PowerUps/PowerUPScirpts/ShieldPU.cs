using UnityEngine;
using System.Collections;

public class ShieldPU : PowerUps
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
        //if player has shields, set players shields to their max hp
        if(player.GetComponent<ShipData>().m_HasShield)
        {
            //check to see if shield health under its max, if not then do nothing
            if (player.GetComponent<ShipData>().m_CurrShield < player.GetComponent<PlayerShip>().m_MaxShieldHP)
            {
                if(player.GetComponent<ShipData>().m_HP < player.GetComponent<PlayerShip>().m_MaxHP)
                {
                    player.GetComponent<ShipData>().m_HP = player.GetComponent<PlayerShip>().m_MaxHP;
                }
                player.GetComponent<PlayerShip>().m_ShieldData.SetShield(player);
                player.GetComponent<ShipData>().m_CurrShield = player.GetComponent<PlayerShip>().m_MaxShieldHP;
            }
            else
            {
                return;
            }
        }
        //if player does not have shields, set HasShield to true at max for player lvl
        else
        {
            if (player.GetComponent<ShipData>().m_HP < player.GetComponent<PlayerShip>().m_MaxHP)
            {
                player.GetComponent<ShipData>().m_HP = player.GetComponent<PlayerShip>().m_MaxHP;
            }
            player.GetComponent<PlayerShip>().m_HasTempShield = true;
            player.GetComponent<ShipData>().m_CurrShield = player.GetComponent<PlayerShip>().m_TempShieldHP;
            player.GetComponent<PlayerShip>().m_ShieldData.SetShield(player);
        }
    }
    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}

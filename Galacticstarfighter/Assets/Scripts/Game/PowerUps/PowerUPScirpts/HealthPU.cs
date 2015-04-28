using UnityEngine;
using System.Collections;

public class HealthPU : PowerUps
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
        //set player health to max
        player.GetComponent<ShipData>().m_HP = player.GetComponent<PlayerShip>().m_MaxHP;
    }

    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}

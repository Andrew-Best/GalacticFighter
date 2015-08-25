using UnityEngine;
using System.Collections;

public class DoubleHealthPU : PowerUps
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
    //set player Health to double maxHP
    public override void ItemAffect(GameObject player)
    {
        player.GetComponent<ShipData>().m_HP = player.GetComponent<PlayerShip>().m_MaxHP * 2;
    }

    public override void UseItem(GameObject player)
    {
            ItemAffect(player);
    }
}
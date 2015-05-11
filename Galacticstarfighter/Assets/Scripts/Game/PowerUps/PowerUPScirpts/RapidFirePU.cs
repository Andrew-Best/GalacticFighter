using UnityEngine;
using System.Collections;

public class RapidFirePU : PowerUps
{
    public override void Start()
    {
        m_IsStorable = true;
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
        //change fire rate unitl respawn
        player.GetComponentInChildren<Weapon>().m_Cooldown *= 0.5f;
    }
    
    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
    
}

using UnityEngine;
using System.Collections;

public class MissilePU : PowerUps
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
        //change player shot to missile with 20 ammo.
        player.GetComponent<ShipData>().m_WeaponState[0].m_Ammo = 20;
        player.GetComponentInChildren<Weapon>().SetProjectile(player.GetComponentInChildren<Weapon>().m_ProjectilePrefabs[3]);
    }
    
    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
    
}

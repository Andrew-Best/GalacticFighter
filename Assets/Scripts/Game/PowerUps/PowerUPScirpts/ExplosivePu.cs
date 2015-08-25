using UnityEngine;
using System.Collections;

public class ExplosivePu : PowerUps
{
    public override void Start()
    {
        m_IsStorable = true;
    }

    public override void Update()
    {
        if(this.isActiveAndEnabled)
        {
            Vector3 movement = new Vector3(0, m_DropSpeed, 0);

            GetComponent<Rigidbody>().velocity = movement;
        }
    }

    //slow moving projectile 
    public override void ItemAffect(GameObject player)
    {
        Debug.Log("Used and Explosive Bomb");
    }
    //damage = 20 + 25% per player damage level

    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}

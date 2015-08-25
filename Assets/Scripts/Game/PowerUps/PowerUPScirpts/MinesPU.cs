using UnityEngine;
using System.Collections;

public class MinesPU : PowerUps
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

    //launch 5 mines that spread out and drift until hit by an enemy
    public override void ItemAffect(GameObject player)
    {
        Debug.Log("Used Mines");
    }
    //damage is = 15/each + 25% per player damage level
    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}

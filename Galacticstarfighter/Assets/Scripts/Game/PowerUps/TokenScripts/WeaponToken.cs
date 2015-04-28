using UnityEngine;
using System.Collections;

public class WeaponToken : PowerUps 
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
        //add token name to a list
        m_PData.m_Tokens.Add(this.name);
    }

    public override void UseItem(GameObject player)
    {
        //add token name to a list
        ItemAffect(player);
    }
}

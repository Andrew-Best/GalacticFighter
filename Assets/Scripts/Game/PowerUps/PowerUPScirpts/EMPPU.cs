using UnityEngine;
using System.Collections;

public class EMPPU : PowerUps
{
    public override void Start()
    {
        m_IsStorable = true;
    }
    //slow moving projectile
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
        Debug.Log("You used an EMP bomb");
    }
    //damage  = 10 + eleiminates shields(if enemy has one)/ disables firing for 5 seconds
    public override void UseItem(GameObject player)
    {
       ItemAffect(player);
    }

}

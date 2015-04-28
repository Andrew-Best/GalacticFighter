using UnityEngine;
using System.Collections;

public class MultiShotPU : PowerUps
{
    //when used set player bolt to fire 3 shots
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
        //Sets players guns to fire 3 shots from each one
        //they will fire parallel to each other
        //damage will be normal for each shot
        Debug.Log("Used MultiShot");
    }
    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}

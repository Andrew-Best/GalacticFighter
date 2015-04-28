using UnityEngine;
using System.Collections;

public class AddLife : PowerUps
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
        Camera.main.GetComponent<GameController>().m_Lives += 1;
    }

    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}
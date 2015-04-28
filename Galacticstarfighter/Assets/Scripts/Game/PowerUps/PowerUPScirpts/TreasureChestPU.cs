using UnityEngine;
using System.Collections;

public class TreasureChestPU : PowerUps
{
    public override void Start()
    {
        m_IsStorable = false;
    }
    public override void Update()
    {
        if(this.isActiveAndEnabled)
        {
            Vector3 movement = new Vector3(0, m_DropSpeed, 0);

            GetComponent<Rigidbody>().velocity = movement;
        }
    }

    public override void ItemAffect(GameObject player)
    {
        //generate randNum between 500 and 15000
        int randNum = Random.Range(500, 15000);

        //apply randNum to players Salvage collected(not total earned until after wave 5 or 10)
        Camera.main.GetComponent<GameController>().m_Salvage += randNum;
    }
    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
 
}

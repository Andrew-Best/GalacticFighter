using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootTable : MonoBehaviour 
{
    public Items m_ItemList;

    private int randNum_;

    public void LootDrop(GameObject parentShip)
    {
        randNum_ = Random.Range(0, 132);

        Vector3 spawnPosition = new Vector3(parentShip.transform.position.x, parentShip.transform.position.y, 0);
        Quaternion spawnRotation = Quaternion.identity;
        /*if(randNum_> 0)
        {
            //test code
            Instantiate(m_ItemList.m_PowerUps[6], spawnPosition, spawnRotation);
        }

        else*/ if(randNum_ <= 1)
        {
            //Bomb(Nuke)[9]

            Instantiate(m_ItemList.m_PowerUps[9], spawnPosition, spawnRotation);
        }

        else if(randNum_ > 1 && randNum_ <= 6)
        {
            //TreasureChest[4]
            Instantiate(m_ItemList.m_PowerUps[4], spawnPosition, spawnRotation);
        }
 
        else if (randNum_ > 6 && randNum_ <= 11)
        {
            //MissileBattery[8]
            Instantiate(m_ItemList.m_PowerUps[8], spawnPosition, spawnRotation);
        }

        else if(randNum_ > 11 && randNum_ <= 16)
        {
            //Free Life[5]
            Instantiate(m_ItemList.m_PowerUps[5], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 16 && randNum_ <= 31)
        {
            //Dobuble Health[2]
            Instantiate(m_ItemList.m_PowerUps[2], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 31 && randNum_ <= 46)
        {
            //DoubleShiled[3]
            Instantiate(m_ItemList.m_PowerUps[3], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 46 && randNum_ <= 61)
        {
            //RapidFire[6]
            Instantiate(m_ItemList.m_PowerUps[6], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 61 && randNum_ <= 81)
        {
            //Missile[7]
            Instantiate(m_ItemList.m_PowerUps[7], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 81 && randNum_ <= 106)
        {
            //Health[0]
            Instantiate(m_ItemList.m_PowerUps[0], spawnPosition, spawnRotation);
        }

        else
        {
            //Shield[1]
            Instantiate(m_ItemList.m_PowerUps[1], spawnPosition, spawnRotation);
        }

        return;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootTable : MonoBehaviour 
{
    public Items m_ItemList;

    private int randNum_;

    public void LootDrop(GameObject parentShip)
    {
        randNum_ = Random.Range(0, 163);

        Vector3 spawnPosition = new Vector3(parentShip.transform.position.x, parentShip.transform.position.y, 0);
        Quaternion spawnRotation = Quaternion.identity;
        if(randNum_> 0)
        {
            //test code
            Instantiate(m_ItemList.m_PowerUps[11], spawnPosition, spawnRotation);
        }

        else if(randNum_ <= 1)
        {
            //Bomb(Nuke)[8]

            Instantiate(m_ItemList.m_PowerUps[8], spawnPosition, spawnRotation);
        }

        else if(randNum_ > 1 && randNum_ <= 6)
        {
            //TreasureChest[4]
            Instantiate(m_ItemList.m_PowerUps[4], spawnPosition, spawnRotation);
        }
 
        else if (randNum_ > 6 && randNum_ <= 11)
        {
            //MissileBattery[11]
            Instantiate(m_ItemList.m_PowerUps[11], spawnPosition, spawnRotation);
        }
        else if(randNum_ > 11 && randNum_ <= 16)
        {
            //Free Life[13]
            Instantiate(m_ItemList.m_PowerUps[13], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 16 && randNum_ <= 27)
        {
            //Dobuble Health[2]
            Instantiate(m_ItemList.m_PowerUps[2], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 27 && randNum_ <= 42)
        {
            //DoubleShiled[3]
            Instantiate(m_ItemList.m_PowerUps[3], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 42 && randNum_ <= 57)
        {
            //MultiShot[9]
            Instantiate(m_ItemList.m_PowerUps[9], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 57 && randNum_ <= 72)
        {
            //Laser[12]
            Instantiate(m_ItemList.m_PowerUps[12], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 72 && randNum_ <= 82)
        {
            //Bomb(Explosive)[5]
            Instantiate(m_ItemList.m_PowerUps[5], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 82 && randNum_ <= 92)
        {
            //Bomb(EMP)[6]
            Instantiate(m_ItemList.m_PowerUps[6], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 92 && randNum_ <= 102)
        {
            //Bomb(Mines)[7]
            Instantiate(m_ItemList.m_PowerUps[7], spawnPosition, spawnRotation);
        }

        else if (randNum_ > 102 && randNum_ <= 122)
        {
            //Missile[10]
            Instantiate(m_ItemList.m_PowerUps[10], spawnPosition, spawnRotation);
        }

        else if (randNum_ < 122 && randNum_ <= 147)
        {
            //Health[0]
            Instantiate(m_ItemList.m_PowerUps[0], spawnPosition, spawnRotation);
        }
        else if (randNum_ > 147 && randNum_ <= 172)
        {
            //more Ammo[14]
            Instantiate(m_ItemList.m_PowerUps[14], spawnPosition, spawnRotation);
        }

        else
        {
            //Shield[1]
            Instantiate(m_ItemList.m_PowerUps[1], spawnPosition, spawnRotation);
        }

        return;
    }
}

using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour 
{
    public const int BASE_UPGRADE_COST = 50;//Base cost of all upgrades, this will be multiplied for each tier of ship as well as each additional upgrade
                                            //How this will work:
                                            //Tier 1 Ship = Base upgrade cost
                                            //Tier 2 Ship = Base upgrade cost * 2
                                            //Tier 3 Ship = Base upgrade cost * 3
                                            //Any Tier Ship First Upgrade = Tier ship base upgrade cost
                                            //Any Tier Ship Second Upgrade = Tier ship Base upgrade cost * 2
                                            //For instance, Tier 2 ship first upgrade cost = 50, second upgrade cost = 100
    public const int BASE_SHIP_COST = 20000;//Base cost of the ships, this - like the upgrade costs - will scale depending on the tier of the ship
    public const int DEFAULT_NUM_LIVES = 3;//The base amount of lives the player can start with
    public const int MAX_UPGRADE_LEVEL = 5;//Maximum amount of upgrades for one slot per ship
    public const int DEFAULT_UPGRADE_AMT = 20;//Amount each upgrade increases it's stat by
    public const int DEFAULT_UPGRADE_MODIFIER = 2;//Amount each level increases damage and engines(multiply current stat buy this number)
    public const float DROP_CHANCE = 0.5f;//Base chance for enemies to drop power ups
    public const int BASE_ENEMY_INVO_SIZE = 3;
}

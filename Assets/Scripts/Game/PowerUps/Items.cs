using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Items : MonoBehaviour 
{
    public List<GameObject> m_PowerUps;

    //drop from engines
    //instant use
    //health regen 25% chance to drop
    //shields(will give temp shields if player doesn't currently have any and will regen them if the player has shields) 25 % chance to drop
    //bonus salvage 25% chance to drop
    //temp double max health 15% chance to drop
    //temp double max shields 15% chance to drop

    //drop from weapons
    //store for use by player choice
    //bombs(medium explosive radius with prox-detection)
        //explosive mine type 10% chance to drop
        //EMP type(disable enemy shields or temporaily preventing them firing and at the player) 10% chance
        //multi-bomb(3-4 smaller bombs that act like mines, each has a slightly smaller blast radius and damage output) 10% chance
        //nuke(kills every enemy on the screen, EXTREMLY RARE DROP) .05% chance to drop
    //Missles(gives 50 missiles that replace the shot until ammo runs out) 
    //Missle Battery(fires 10 missiles simultaniously that track nearby enemies)
    //multishot(fires 3 bolts 1 forward, one left one 45 degree angle and on right on a 45 degree angle) 20% chance
    //Laser(solid beam that last for 10 seconds doing 3 times the damage of a normal bolt) 5% chance

    //specific drops from bosses(guaranteed)
    //free random upgrade(weapon, shield, engine, health) 100% chance of dropping one of these, each has a 25% chance of being dropped
}

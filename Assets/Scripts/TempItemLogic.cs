using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempItemLogic : MonoBehaviour
{
    //These are placeholder stats. Static to prevent any conflict between instances; this way player stats will remain consistant
    //throughout all scripts
    static int playerHealth = 100;
    static int playerMana = 50;

    //a dictionary to declare which actions the player has equipped. This will need to be altered depending on how the player chooses
    //to equip their actions but for now it is hardcoded for simplicity
    Dictionary<int, Action> actions = new Dictionary<int, Action>
    {
        {1, UseHealthPotion},
        {2, UseManaPotion },
        {3, CastFireball },
        {4, ThrowMolotov }

    };

   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.EnablePlayerInput)
        {
            return;
        }

        //checking for when the player presses the keys and performs the corresponding action
        if (Input.GetKeyDown("1"))
        {
            actions[1]();
        }
        if (Input.GetKeyDown("2"))
        {
            actions[2]();
        }
        if (Input.GetKeyDown("3"))
        {
            actions[3]();
        }
        if (Input.GetKeyDown("4"))
        {
            actions[4]();
        }
        
    }

    static void UseHealthPotion()
    {
        //simply adds to the players health. Again, specific numbers are placeholders. 
        playerHealth += 25;

        //We dont want the player to overheal, so for this instance ive treated 100 as max health and made sure to not let the
        //players health go over
        if(playerHealth > 100)
        {
            playerHealth = 100;
        }

        Debug.Log("playerHealth = " + playerHealth);
    }

    static void UseManaPotion()
    {
        //simply adds to the players mana. Again, specific numbers are placeholders. 
        playerMana += 10;

        //We dont want the player to go over their maximum mana, so for this instance ive treated 50 as max mana and made sure to
        //not let the players mana go over
        if (playerMana > 50)
        {
            playerMana = 50;
        }

        Debug.Log("playerMana = " + playerMana);
    }

    //The last two methods are just placeholders for the purposes of testing if the "perform action" logic is working
    static void CastFireball()
    {
        playerMana -= 10;
        Debug.Log("Fireball!!!!! You have " + playerMana + " mana left.");
    }

    static void ThrowMolotov()
    {
        Debug.Log("YEAHHHHH FIRE BABY WOOOOOO!!!");
    }

    static void HealSpell()
    {

    }
}

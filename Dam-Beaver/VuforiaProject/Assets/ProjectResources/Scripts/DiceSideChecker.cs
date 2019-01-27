using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSideChecker : MonoBehaviour
{
    Vector3 dice_velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        dice_velocity = DiceScript.dice_velocity;
    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log("Collision Detection");
        if (dice_velocity.x == 0f && dice_velocity.y == 0f && dice_velocity.z == 0f)
        {
            Debug.Log("Search Dice Results");
            Debug.Log(col.gameObject.name);
            switch (col.gameObject.name)
            {
                // need to assign the opposite side number
                case "Side1":
                    TextDiceNumberShow.dice_number = 6;
                    break;
                case "Side2":
                    TextDiceNumberShow.dice_number = 5;
                    break;
                case "Side3":
                    TextDiceNumberShow.dice_number = 4;
                    break;
                case "Side4":
                    TextDiceNumberShow.dice_number = 3;
                    break;
                case "Side5":
                    TextDiceNumberShow.dice_number = 2;
                    break;
                case "Side6":
                    TextDiceNumberShow.dice_number = 1;
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{

    // Variables that will be inputted in the inspector.
    public string playerName;
    public int playerLevel;
    public string playerClass;
    public int constitutionScore;
    public bool isHillDwarf;
    public bool hasToughFeat;
    public bool averageOrRolled; // Average is false and rolled is true.
    private int maxHealth;
    private int expectedValue;


    // Start is called before the first frame update
    void Start()
    {
        CalculateHitPoints();
        Debug.Log($"(Solution 1) {playerName} is level {playerLevel}. Their HP is {maxHealth}");
    }

    void CalculateHitPoints() // Does as the name suggests.
    {
        maxHealth = 0;

        // Set our number of die to our player number since they coincide.
        int numberOfDie = playerLevel;


        int dieLevel = 0; // the number of pips on the die

        //Use switch statement to determine which hit die we are using.
        //

        Dictionary<string, int> classDie = new Dictionary<string, int>
        {
            { "Sorcerer", 6 },
            { "Wizard", 6 },

            { "Artificer", 8 },
            { "Bard", 8 },
            { "Cleric", 8 },
            { "Druid", 8 },
            { "Monk", 8 },
            { "Rogue", 8 },
            { "Warlock", 8 },

            { "Fighter", 10 },
            { "Ranger", 10 },
            { "Paladin", 10 },

            { "Barbarian", 12 },
        };

        dieLevel = classDie[playerClass];


        int modifier = 0; // Used to modify the hp

        //Depending on the player's level we adjust the modifier.
        //Use switch statement for each.
        switch (constitutionScore)
        {
            case 1:
                modifier = -5;
                break;

            case 2:
            case 3:
                modifier = -4;
                break;

            case 4:
            case 5:
                modifier = -3;
                break;

            case 6:
            case 7:
                modifier = -2;
                break;

            case 8:
            case 9:
                modifier = -1;
                break;

            case 10:
            case 11:
                modifier = 0;
                break;

            case 12:
            case 13:
                modifier = 1;
                break;

            case 14:
            case 15:
                modifier = 2;
                break;

            case 16:
            case 17:
                modifier = 3;
                break;

            case 18:
            case 19:
                modifier = 4;
                break;

            case 20:
            case 21:
                modifier = 5;
                break;

            case 22:
            case 23:
                modifier = 6;
                break;

            case 24:
            case 25:
                modifier = 7;
                break;

            case 26:
            case 27:
                modifier = 8;
                break;

            case 28:
            case 29:
                modifier = 9;
                break;

            case 30:
                modifier = 10;
                break;

            default:
                modifier = 11;
                break;
        }


        //If statement to check if average. 
        if (!averageOrRolled)
        {
            //Calculate expected value Return.
            CalculateExpectedValue(numberOfDie, dieLevel, modifier);

            maxHealth = expectedValue;
        }


        //If statement to determine if you are a dwarf. Add playerLevel to maxHealth;
        if (isHillDwarf) 
        {
            maxHealth += playerLevel;
        }

        //If statement to see if hasToughFeat. Add playerLevel*2 to maxHealth;
        if (hasToughFeat)
        {
            maxHealth += (playerLevel * 2);
        }

        if (averageOrRolled)
        {
            var rollArray = new int[numberOfDie];

            //For loop based on the number of die.
            //{
            //	Roll die 
            //	Take that value and add it maxHealth.
            //}
            for (int i = 0; i < numberOfDie; i++)
            {
                //Modifier + die
                rollArray[i] = Random.Range(1, dieLevel) + modifier;
            }

            foreach (var value in rollArray)
            {
                maxHealth += value;
            }
        }

    }

    void CalculateExpectedValue(int numberOfDie, int dieLevel, int constitutionModifier)
    {
        float average = 0;

        average = ((dieLevel + 1) / 2f) * numberOfDie + (constitutionModifier * numberOfDie);

        expectedValue = (int) average;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionTwo : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        CalculateHitPoints();
        Debug.Log($"(Solution 2) {playerName} is level {playerLevel}. Their HP is {maxHealth}");
    }

    public void CalculateHitPoints()
    {
        maxHealth = 0;

        int numberOfDie = playerLevel;

        int dieLevel = PlayerClassHelper.GetClassDie(playerClass);

        int modifier = PlayerClassHelper.GetConstitutionModifier(constitutionScore);

        if (!averageOrRolled) 
        {
            int expectedValue = PlayerClassHelper.CalculateExpectedValue(numberOfDie, dieLevel, modifier);
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
            maxHealth += PlayerClassHelper.RollAllDie(numberOfDie, dieLevel, modifier);
        }
    }

}

public class PlayerClassHelper
{
    public static int GetClassDie(string playerClass)
    {
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

        if (!classDie.ContainsKey(playerClass))
            return 0;

        return classDie[playerClass];
    }

    public static int GetConstitutionModifier(int constitutionScore)
    {
        int modifier = 0;

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

        return modifier;
    }

    public static int CalculateExpectedValue(int numberOfDie, int dieLevel, int constitutionModifier)
    {
        float average = 0;

        average = ((dieLevel + 1) / 2f) * numberOfDie + (constitutionModifier * numberOfDie);

        return (int) average;
    }

    public static int RollAllDie(int numberOfDie, int dieLevel, int constitutionModifier)
    {
        int total = 0;

        for (int i = 0; i < numberOfDie; i++)
            total += Random.Range(1, dieLevel) + constitutionModifier;

        return total;
    }

}

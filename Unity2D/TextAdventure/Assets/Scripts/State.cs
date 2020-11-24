using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(19, 19)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [SerializeField] int health;
    [SerializeField] int potions;
    [SerializeField] int armour;
    [SerializeField] int damage;
    [SerializeField] int attack;
    [SerializeField] int requirement;
    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetArmour()
    {
        return armour;
    }

    public int GetPotions()
    {
        return potions;
    }

    public int GetAttack()
    {
        return attack;
    }

    public int GetRequarement()
    {
        return requirement;
    }

    public void GiveStartingStates(int h,int p,int ar, int at)
    {
        health = h;
        potions = p;
        armour = ar;
        attack = at;
    }
}

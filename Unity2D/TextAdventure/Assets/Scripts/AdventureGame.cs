using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{

    [SerializeField] Text screenText;
    [SerializeField] Text barHealth;
    [SerializeField] Text barPotions;
    [SerializeField] Text barArmour;
    [SerializeField] Text barAttack;
    [SerializeField] State startingState;
    [SerializeField] State deathState;
    [SerializeField] int health;
    [SerializeField] int potions;
    [SerializeField] int armour;
    [SerializeField] int attack;
    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        deathState.GiveStartingStates(health, potions, armour, attack);
        ShowText();
    }

    // Update is called once per frame
    void Update()
    {
        DeadCheck();
        ShowStats();
        ManageState();
    }



    private void DeadCheck()
    {
        if (health <= 0)
        {

            state = deathState;
            ShowText();
            health = deathState.GetHealth();
            armour = deathState.GetArmour();
            potions = deathState.GetPotions();
            attack = deathState.GetAttack();
        }
    }

    private void ShowStats()
    {
        barHealth.text = health.ToString();
        barArmour.text = armour.ToString();
        barAttack.text = attack.ToString();
        barPotions.text = potions.ToString();
    }

    private void ManageState()
    {
        if (Input.anyKey)
        {
            var nextStates = state.GetNextStates();
            for (int index = 0; index < nextStates.Length; index++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + index) && attack >= nextStates[index].GetRequarement())
                {
                    state = nextStates[index];
                    AdjustValues();
                    ShowText();
                }
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Heal();
            }
        }
    }

    private void Heal()
    {
        if (potions > 0)
        {
            potions -= 1;
            health += 50;
        }
    }

    private void ShowText()
    {
        screenText.text = state.GetStateStory();
    }

    private void AdjustValues()
    {
        if (state.GetDamage() != 0)
        {
            if ((state.GetDamage() - armour / 10) > 0)
                health = health - (state.GetDamage() - armour / 10);
            else
                health -= 1;
        }
        if (state.GetHealth() != 0)
        {
            health += state.GetHealth();
        }
        if (state.GetArmour() != 0)
        {
            armour += state.GetArmour();
        }
        if (state.GetPotions() != 0)
        {
            potions += state.GetPotions();
        }
        if (state.GetAttack() != 0)
        {
            attack += state.GetAttack();
        }
    }

}

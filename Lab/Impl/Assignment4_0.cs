using System;
using System.Collections.Generic;

namespace Lab.Impl;

public class Assignment4_0 : IBaseLab
{
    public void Execute()
    {
        Utils.WriteLine("Input the amount of dice and the dice type below.");
        Utils.WriteLine("For example, type `4d20` to throw four dices with 20 sides.");
        Utils.WriteLine("You can also chain them. `4d20 3d6` for four 20-sided dices, and three 6-sided dices.");
        string dices = Utils.PromptString("|: Dices :|: ");
        string[] diceStrings = dices.Trim().Split(" ");
        List<Dice> diceInstances = new List<Dice>();
        foreach (string dice in diceStrings)
        {
            try
            {
                Dice[] ret = Dice.FromDiceString(dice);
                foreach (Dice instance in ret)
                {
                    diceInstances.Add(instance);
                }
            }
            catch (Exception e)
            {
                Utils.WriteLine($"Could not transform {dice} into a Dice instance!\n{e.Message}");
                return;
            }
        }

        int sum = 0;
        diceInstances.ForEach(dice =>
        {
            int roll = dice.Roll();
            sum = sum + roll;
            Utils.WriteLine($"D{dice.Sides} rolled a {roll}!");
        });
        Utils.WriteLine($"Total: {sum}");
    }

    public bool Test()
    {
        throw new System.NotImplementedException();
    }
}
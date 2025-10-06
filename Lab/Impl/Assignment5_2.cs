namespace Lab.Impl;

public class Assignment5_2 : IBaseLab
{
    public void Execute()
    {
        Utils.WriteLine($"Result: {ThrowD6(Utils.PromptInt("|: Amount of dice :|: ") ?? 0)}");
    }

    public int ThrowD6(int count)
    {
        int sum = 0;
        Dice dice = new Dice(6);
        for (int i = 0; i < count; i++)
        {
            sum += dice.Roll();
        }

        return sum;
    }

    public bool Test()
    {
        throw new System.NotImplementedException();
    }
}
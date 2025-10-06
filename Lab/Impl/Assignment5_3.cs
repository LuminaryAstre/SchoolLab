using System;

namespace Lab.Impl;

public class Assignment5_3 : IBaseLab
{
    public void Execute()
    {
        Console.WriteLine(Travel("Göteborg", 5, 6000));
        Console.WriteLine(Travel("Göteborg", 2, 2000));
        Console.WriteLine(Travel("Kiruna", 1, 500));
    }

    public int HotelCost(int nights)
    {
        return 1400 * nights;
    }

    public int FlightCost(string destination)
    {
        switch (destination)
        {
            case "Göteborg":
            {
                return 1000;
            }
            case "Stockholm":
            {
                return 2000;
            }
            case "Gävle":
            {
                return 2200;
            }
            case "Kiruna":
            {
                return 3000;
            }
            default:
            {
                return 0;
            }
        }
    }

    public int RentCar(int days)
    {
        int price = 400 * days;
        if (days >= 7) price -= 500;
        else if (days >= 3) price -= 200;
        return price;
    }
 
    public int Travel(string destination, int days, int money)
    {
        return FlightCost(destination) + RentCar(days) + HotelCost(days) + money;
    }
    
    public bool Test()
    {
        throw new System.NotImplementedException();
    }
}
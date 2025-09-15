using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* test fixtures */

            Subscription newPlan = new Subscription(1, 1, 4);

            User[] noUsers = new User[0];

            User[] constantUsers = {
                  new User(1, "Employee #1", new DateTime(2018, 11, 4), DateTime.MaxValue, 1),
                  new User(2, "Employee #2", new DateTime(2018, 12, 4), DateTime.MaxValue, 1)
            };

                        User[] userSignedUp = {
                  new User(1, "Employee #1", new DateTime(2018, 11, 4), DateTime.MaxValue, 1),
                  new User(2, "Employee #2", new DateTime(2018, 12, 4), DateTime.MaxValue, 1),
                  new User(3, "Employee #3", new DateTime(2019, 1, 10), DateTime.MaxValue, 1),
            };

            /* end test fixtures */
        }

    }
}



public class Subscription
{
    public Subscription() { }
    public Subscription(int id, int customerId, int monthlyPriceInDollars)
    {
        this.Id = id;
        this.CustomerId = customerId;
        this.MonthlyPriceInDollars = monthlyPriceInDollars;
    }

    public int Id;
    public int CustomerId;
    public int MonthlyPriceInDollars;
}

public class User
{
    public User() { }
    public User(int id, string name, DateTime activatedOn, DateTime deactivatedOn, int customerId)
    {
        this.Id = id;
        this.Name = name;
        this.ActivatedOn = activatedOn;
        this.DeactivatedOn = deactivatedOn;
        this.CustomerId = customerId;
    }

    public int Id;
    public string Name;
    public DateTime ActivatedOn;
    public DateTime DeactivatedOn;
    public int CustomerId;
    public decimal dailyRate
    {
        get
        {
            throw new NotImplementedException();
        }
    }
    public bool IsActive
    {
        get
        {
            if (DateTime.Now < this.ActivatedOn)
                return true;
            else
                return false;
        }
    }

}

public class Challenge
{
    //Calculate a daily rate for the active subscription tier
    //For each day of the month, identify which users were active that day
    //Multiply the number of active users for the day by the daily rate to calculate the total for the day
    //Return the running total for the month at the end, rounded to 2 decimal places
    public static Decimal BillFor(string month, Subscription activeSubscription, User[] users)
    { 

        decimal runningTotal = 0;
        return runningTotal;
    }

    /*******************
    * Helper functions *
    *******************/

    /**
    Takes a DateTime object and returns a DateTime which is the first day
    of that month. For example:

    FirstDayOfMonth(new DateTime(2019, 2, 7)) // => new DateTime(2019, 2, 1)
    **/
    private static DateTime FirstDayOfMonth(DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }

    /**
    Takes a DateTime object and returns a DateTime which is the last day
    of that month. For example:

    LastDayOfMonth(new DateTime(2019, 2, 7)) // => new DateTime(2019, 2, 28)
    **/
    private static DateTime LastDayOfMonth(DateTime date)
    {
        return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }

    /**
    Takes a DateTime object and returns a DateTime which is the next day.
    For example:

    NextDay(new DateTime(2019, 2, 7))  // => new DateTime(2019, 2, 8)
    NextDay(new DateTime(2019, 2, 28)) // => new DateTime(2019, 3, 1)
    **/
    private static DateTime NextDay(DateTime date)
    {
        return date.AddDays(1);
    }
}
/*
    Problem:
     Restoranın avtomatlaşdırılması sistemini dizayn edək. Bu sistem müştərilərin sifarişlərini qəbul edir və onları hazırlayır.
     və sifarişlərə xidmət göstərmək üçün interfeys təmin etməlidir.
     Bununla belə, müxtəlif növ sifarişlərin hazırlanması (məsələn, yeməklər, içkilər və s.)
     və müxtəlif yollarla xidmət edilməlidir.
     Bu halda biz hər bir sifariş növü üçün fərqli bir əməliyyat sinfi yazmaq və bu sinifləri birləşdirmək istəyirik.
 */

/*
    Helli:
     Komanda dizayn nümunəsi sorğuları obyekt kimi əhatə edir və onları müstəqil edir.
     Bu dizayn nümunəsi sorğuları müştəridən ayıraraq əmr obyekti vasitəsilə emal etməyə imkan verir.
     Beləliklə, müştəri hansı əmrin hansı hərəkəti yerinə yetirəcəyini bilmir və bu proses komanda obyekti tərəfindən idarə olunur.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
       
        ICommand cookorder = new CookOrderCommand("Steak");
        ICommand drinkorder = new PrepareDrinkCommand("Cola");
        ICommand serveorder = new ServeOrderCommand("Steak and Cola");
     
        Restaurant restaurant = new Restaurant();
      
        restaurant.TakeOrder(cookorder);
        restaurant.TakeOrder(drinkorder);
        restaurant.TakeOrder(serveorder);
    }
}

// Invoker class
class Restaurant
{
    public void TakeOrder(ICommand command)
    {
        command.Execute();
    }
}

// Command interface
interface ICommand
{
    void Execute();
}

// Concrete command
class CookOrderCommand : ICommand
{
    private string meal;

    public CookOrderCommand(string meal)
    {
        this.meal = meal;
    }

    public void Execute()
    {
        Console.WriteLine("Cooking the meal: " + meal);
    }
}

// Concrete command
class PrepareDrinkCommand : ICommand
{
    private string drink;

    public PrepareDrinkCommand(string drink)
    {
        this.drink = drink;
    }

    public void Execute()
    {
        Console.WriteLine("Preparing the drink: " + drink);
    }
}

// Concrete command
class ServeOrderCommand : ICommand
{
    private string item;

    public ServeOrderCommand(string item)
    {
        this.item = item;
    }

    public void Execute()
    {
        Console.WriteLine("Serving: " + item);
    }
}




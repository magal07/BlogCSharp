using BlogCSharp.Models;
using BlogCSharp.Repositories;

namespace BlogCSharp.Screens.TagScreens;

public static class ListTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Lista de Tags");
        Console.WriteLine("---------------------");
        List();
        Console.ReadKey();
        MenuTagScreen.Load();
    }

    private static void List()
    {
        var repository = new Repository<Tag>(Database.Connection);
        var tags = repository.Get();
        foreach (var item in tags)
        {
            Console.WriteLine($"{item.Id} - {item.Name} - {item.Slug}");
        }
    }
}
using BlogCSharp.Models;
using BlogCSharp.Repositories;

namespace BlogCSharp.Screens.TagScreens;

public static class DeleteTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Excluir uma Tag");
        Console.WriteLine("---------------------");

        Console.Write("Qual o id da tag a ser excluida? ");
        var id = Console.ReadLine();

        Delete(int.Parse(id));
        Console.ReadKey();
        MenuTagScreen.Load();
    }
    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<Tag>(Database.Connection);
            repository.Delete(id);
            Console.WriteLine("Tag excluída com sucesso");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível excluir esta tag");
            Console.WriteLine(ex.Message);
        }
    }
}

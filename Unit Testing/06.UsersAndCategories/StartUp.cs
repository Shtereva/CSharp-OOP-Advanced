public class StartUp
{
    public static void Main()
    {
        var cat = new Category("Unity");
        var cat2 = new Category("Unit");
        var cat3 = new Category("Uni");
        var cat4 = new Category("Uniiiiii");

        var user = new User("Pesho");
        var user2 = new User("Gosho");
        var user3 = new User("Misho");

        var repo = new Repository();

        repo.AddCategories(cat, cat2, cat3, cat4);
        repo.AddUsers(user, user2, user3);

        repo.AssignChildCategory("Unity", "Uniiiiii");
        repo.AssignChildCategory("Uni", "Unit");
        repo.AssignChildCategory("Uni", "Unity");

        repo.AssignUserToCategory("Pesho", "Unity");

        repo.RemoveCategories("Unity");
    }
}

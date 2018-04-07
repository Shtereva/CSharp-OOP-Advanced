using System.Linq;
using NUnit.Framework;

public class IntegrationTests
{
    private Repository repo;

    [SetUp]
    public void Initialize()
    {
        this.repo = new Repository();

        var cat = new Category("Unity");
        var cat2 = new Category("Unit");
        var cat3 = new Category("Uni");
        var cat4 = new Category("Uniiiiii");

        var user = new User("Pesho");
        var user2 = new User("Gosho");
        var user3 = new User("Misho");

        this.repo.AddCategories(cat, cat2, cat3, cat4);
        this.repo.AddUsers(user, user2, user3);
    }

    [Test]
    public void AssignUserToCategory()
    {
        this.repo.AssignUserToCategory("Pesho", "Unity");

        var category = this.repo.Categories.SingleOrDefault(c => c.Name == "Unity");
        var user = this.repo.Users.SingleOrDefault(u => u.Name == "Pesho");

        Assert.IsTrue(category.Users.Contains(user));
        Assert.IsTrue(user.Categories.Contains(category));
    }

    [Test]
    public void AssignChildCategoryWithoutParentCategoryToSingleCategory()
    {
        this.repo.AssignChildCategory("Unity", "Uniiiiii");

        var parentCategory = this.repo.Categories.SingleOrDefault(x => x.Name == "Uniiiiii");
        var childCategory = this.repo.Categories.SingleOrDefault(x => x.Name == "Unity");

        Assert.IsTrue(parentCategory.Categories.Contains(childCategory));
    }

    [Test]
    public void AssignChildCategoryFromOneParentCategoryToAnother()
    {
        this.repo.AssignChildCategory("Uni", "Unit");
        this.repo.AssignChildCategory("Uni", "Unity");

        var parentCategory = this.repo.Categories.SingleOrDefault(x => x.Name == "Unity");
        var childCategory = this.repo.Categories.SingleOrDefault(x => x.Name == "Uni");

        var possibleParentCategory = this.repo.Categories
            .FirstOrDefault(x => x.Name == "Unit");


        Assert.IsFalse(possibleParentCategory.Categories.Contains(childCategory));

        Assert.IsTrue(parentCategory.Categories.Contains(childCategory));

        CollectionAssert.AreEqual(childCategory.Users, parentCategory.Categories.SingleOrDefault(c => c.Name == "Uni").Users);
    }

    [Test]
    public void MoveUsersFromCategoryToRemoveToItsChildCategory()
    {
        this.repo.AssignChildCategory("Uni", "Unit");

        var categoryToRemove = this.repo.Categories
            .FirstOrDefault(x => x.Name == "Unit");

        var users = categoryToRemove.Users;

        var childCategory = this.repo.Categories
            .FirstOrDefault(x => x.Name == "Uni");

        this.repo.RemoveCategories("Unit");

        foreach (var user in users)
        {
            Assert.IsTrue(user.Categories.Contains(childCategory));
            Assert.IsTrue(childCategory.Users.Contains(user));
        }

        Assert.IsFalse(this.repo.Categories.Contains(categoryToRemove));
        CollectionAssert.AreEqual(childCategory.Users, users);
    }

    [Test]
    public void RemoveCategoryDeleteRelationFromItsParentCategory()
    {
        this.repo.AssignChildCategory("Unit", "Unity");
        this.repo.AssignChildCategory("Uni", "Unit");

        var categoryToRemove = this.repo.Categories
            .FirstOrDefault(x => x.Name == "Unit");

        var parentCategory = this.repo.Categories
            .FirstOrDefault(x => x.Name == "Unity");

        this.repo.RemoveCategories("Unit");

        Assert.IsFalse(parentCategory.Categories.Contains(categoryToRemove));
    }
}

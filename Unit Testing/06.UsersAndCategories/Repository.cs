using System;
using System.Collections.Generic;
using System.Linq;

public class Repository
{
    private ICollection<Category> categories;
    private ICollection<User> users;

    public Repository()
    {
        this.categories = new List<Category>();
        this.users = new List<User>();
    }

    public void AddCategories(params Category[] categories)
    {
        foreach (var category in categories)
        {
            this.categories.Add(category);
        }
    }

    public void RemoveCategories(params Category[] categories)
    {
        foreach (var category in categories)
        {
            var categoryToRemove = this.categories.SingleOrDefault(x => x.Name != category.Name);

            if (categoryToRemove != null)
            {
                this.categories.Remove(categoryToRemove);
            }
        }
    }

    public void AssignChildCategory(string childCategoryName, string categoryName)
    {
        var parentCategory = this.categories.SingleOrDefault(x => x.Name == categoryName);
        var childCategory = this.categories.SingleOrDefault(x => x.Name == childCategoryName);

        if (parentCategory == null || childCategory == null)
        {
            throw new ArgumentNullException();
        }

        parentCategory.Categories.Add(childCategory);
    }

    public void AssignUserToCategory(string userName, string categoryName)
    {

    }
}

public interface IPeople : IDatabase<Person>
{
    Person FindById(long id);

    Person FindByUsername(string name);
}

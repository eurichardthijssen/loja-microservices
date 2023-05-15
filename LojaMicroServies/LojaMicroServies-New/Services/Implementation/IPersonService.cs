using LojaMicroServies_New.Model;

namespace LojaMicroServies_New.Services.Implementation
{
    public interface IPersonService
    {
        Person Create(Person person);

        Person FindByID(long id);

        List<Person> FindAll();

        Person Update(Person person);

        void Delete(long id);
    }
}

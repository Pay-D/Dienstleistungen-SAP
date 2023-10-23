using Dienstleistungen_SAP.DataModels;
using System.Collections.ObjectModel;

namespace Dienstleistungen_SAP.Repositorys;

public class UserRepository
{
    private static UserRepository instance;

    private UserRepository() { }

    public static UserRepository getInstance()
    {
        if (instance == null)
        {
            instance = new UserRepository();
        }
        return instance;
    }

    public ObservableCollection<User> users = new ObservableCollection<User>() {
           
    };

    public ObservableCollection<User> getAll()
    {
        return users;
    }

    public void add(User user)
    {
        users.Add(user);
    }

    public void update(User user)
    {
        throw new NotImplementedException();
    }
}

using Dienstleistungen_SAP.DataModels;
using System.Collections.ObjectModel;

namespace Dienstleistungen_SAP.Repositorys;

public class UserRepository
{

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

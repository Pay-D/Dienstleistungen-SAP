using CommunityToolkit.Maui.Core.Extensions;
using Dienstleistungen_SAP.DataModels;
using Dienstleistungen_SAP.Firebase;
using System.Collections.ObjectModel;

namespace Dienstleistungen_SAP.Repositorys;

public class UserRepository
{
    private FirestoreProvider firestoreProvider;

    public UserRepository(FirestoreProvider firestoreProvider)
    {
        this.firestoreProvider = firestoreProvider;
    }

    public ObservableCollection<User> getAll()
    {
        var users = firestoreProvider.GetAll<User>();
        return users.ToObservableCollection();
    }

    public User getById(string id)
    {
        return firestoreProvider.Get<User>(id);
    }

    public async void addOrUpdate(User user)
    {
        try
        {
            firestoreProvider.AddOrUpdate(user);
        }
        catch (Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("User", e.Message, "OK");
            throw;
        }

    }
}

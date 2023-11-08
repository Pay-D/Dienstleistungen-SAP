using CommunityToolkit.Maui.Core.Extensions;
using Dienstleistungen_SAP.DataModels;
using Dienstleistungen_SAP.Firebase;
using System.Collections.ObjectModel;

namespace Dienstleistungen_SAP.Repositorys;

public class ServiceRepository
{

    private FirestoreProvider firestoreProvider;

    public ServiceRepository(FirestoreProvider firestoreProvider)
    {
        this.firestoreProvider = firestoreProvider;
    }

    public ObservableCollection<Service> getByUserId(string userId)
    {
        var services = firestoreProvider.WhereEqualTo<Service>("UserId",userId);
        return services.ToObservableCollection();
    }

    public ObservableCollection<Service> getByServiceType(Service.ServiceType type)
    {
        var services = firestoreProvider.WhereEqualTo<Service>("Type", type);
        return services.ToObservableCollection();
    }

    public Service getById(string id)
    {
        return firestoreProvider.Get<Service>(id);
    }

    public ObservableCollection<Service> getAll()
    {
        var services = firestoreProvider.GetAll<Service>();
        return services.ToObservableCollection();
    }

    public async void addOrUpdate(Service service)
    {
        try { 
            firestoreProvider.AddOrUpdate(service);
        }
        catch (Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("Service", e.Message, "OK");
            throw;
        }
    }
}

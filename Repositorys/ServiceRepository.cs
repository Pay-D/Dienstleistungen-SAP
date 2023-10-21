using CommunityToolkit.Mvvm.ComponentModel;
using Dienstleistungen_SAP.DataModels;
using System.Collections.ObjectModel;

namespace Dienstleistungen_SAP.Repositorys;

public class ServiceRepository
{
    private static ServiceRepository instance;

    private ServiceRepository() {}

    public static ServiceRepository getInstance()
    {
        if (instance == null)
        {
            instance = new ServiceRepository();
        }
        return instance;
    }

    public ObservableCollection<Service> services = new ObservableCollection<Service>() {
           new Service() { Id=1, Title = "Test1", CreationDate = DateTime.Now, Description = "Test1Desc", Plz="99999", Type = Service.ServiceType.Request},
           new Service() { Id=2, Title = "Test2", CreationDate = DateTime.Now, Description = "Test2Desc", Plz="99999", Type = Service.ServiceType.Request},
           new Service() { Id=3, Title = "Test3", CreationDate = DateTime.Now, Description = "Test3Desc", Plz="99999", Type = Service.ServiceType.Offer},
           new Service() { Id=4, Title = "Test4", CreationDate = DateTime.Now, Description = "Test4Desc", Plz="99999", Type = Service.ServiceType.Offer}
    };

    public ObservableCollection<Service> getAll()
    {
        return services;
    }

    public void add(Service service)
    {
        services.Add(service);
    }

    public void update(Service service)
    {
        throw new NotImplementedException();
    }
}

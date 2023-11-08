using Dienstleistungen_SAP.Firebase;
using Google.Cloud.Firestore;

namespace Dienstleistungen_SAP.DataModels;

[FirestoreData]
public class Service: IFirebaseEntity
{
    public Service()
    {
        Id = Guid.NewGuid().ToString("N");
    }

    public Service(DateTime creationDate, string plz, string description, string title, string userId)
    {
        Id = Guid.NewGuid().ToString("N");
        CreationDate = creationDate;
        Plz = plz;
        Description = description;
        Title = title;
        UserId = userId;
    }

    [FirestoreProperty]
    public string Id { get; set; }
    [FirestoreProperty]
    public DateTime CreationDate { get; set; }
    [FirestoreProperty]
    public string Plz { get; set; }
    [FirestoreProperty]
    public string Description { get; set; }
    [FirestoreProperty]
    public string Title { get; set; }
    [FirestoreProperty]
    public string UserId { get; set; }
    [FirestoreProperty]
    public ServiceType Type { get; set; }

    public enum ServiceType
    {
        Offer,
        Request
    }
}

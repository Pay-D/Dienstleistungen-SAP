using Dienstleistungen_SAP.Firebase;
using Google.Cloud.Firestore;

namespace Dienstleistungen_SAP.DataModels;
[FirestoreData]
public class User: IFirebaseEntity
{
    public User()
    {
        Id = Guid.NewGuid().ToString("N");
    }


    [FirestoreProperty]
    public string Id { get; set; }

    [FirestoreProperty]
    public string LastName { get; set; }
    [FirestoreProperty]
    public string FirstName { get; set; }
    [FirestoreProperty]
    public string Email { get; set; }
    [FirestoreProperty]
    public string Phone { get; set; }
    [FirestoreProperty]
    public string Plz { get; set; }
    [FirestoreProperty]
    public string City { get; set; }
}

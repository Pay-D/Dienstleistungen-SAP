using Google.Cloud.Firestore;

namespace Dienstleistungen_SAP.Firebase;

public class FirestoreProvider
{
    private readonly FirestoreDb _fireStoreDb = null!;

    public FirestoreProvider(FirestoreDb fireStoreDb)
    {
        _fireStoreDb = fireStoreDb;
    }

    public void AddOrUpdate<T>(T entity) where T : IFirebaseEntity
    {
        var document = _fireStoreDb.Collection(typeof(T).Name).Document(entity.Id);
        document.SetAsync(entity).GetAwaiter().GetResult();
    }

    public T Get<T>(string id) where T : IFirebaseEntity
    {
        var document = _fireStoreDb.Collection(typeof(T).Name).Document(id);
        var snapshot = document.GetSnapshotAsync().GetAwaiter().GetResult();
        return snapshot.ConvertTo<T>();
    }

    public IReadOnlyCollection<T> GetAll<T>() where T : IFirebaseEntity
    {
        var collection = _fireStoreDb.Collection(typeof(T).Name);
        var snapshot = collection.GetSnapshotAsync().GetAwaiter().GetResult();
        return snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
    }

    public IReadOnlyCollection<T> WhereEqualTo<T>(string fieldPath, object value) where T : IFirebaseEntity
    {
        return GetList<T>(_fireStoreDb.Collection(typeof(T).Name).WhereEqualTo(fieldPath, value));
    }

    // just add here any method you need here WhereGreaterThan, WhereIn etc ...

    private static IReadOnlyCollection<T> GetList<T>(Query query) where T : IFirebaseEntity
    {
        try
        {
            var snapshot = query.GetSnapshotAsync().GetAwaiter().GetResult();
            return snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}

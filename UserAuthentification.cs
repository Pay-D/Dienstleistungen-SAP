using Firebase.Auth;

namespace Dienstleistungen_SAP;

public class UserAuthentification
{
    public bool IsAuthentificated { get; private set;}
    
    private static UserAuthentification instance;

    private UserAuthentification() 
    {
        IsAuthentificated = false;
    }

    private UserCredential userCredential;

    public UserCredential UserCredential {
        private get => userCredential;
        set {
            userCredential = value;
            IsAuthentificated = true;
        }
    }

    public static UserAuthentification getInstance()
    {
        if (instance == null)
        {
            instance = new UserAuthentification();
        } 
        return instance;
    }

    public string GetCurrentUserId()
    {
        return userCredential.User.Uid;
    }

}

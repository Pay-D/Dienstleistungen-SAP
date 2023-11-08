using System.Text.Json.Serialization;

namespace Dienstleistungen_SAP.Firebase;

public class FirebaseSettings
{
    [JsonPropertyName("project_id")]
    public string ProjectId = "dienstleistungen-sap";

    [JsonPropertyName("private_key_id")]
    public string PrivateKeyId = "31dce3a6afe9e35c4120425dda84ee9c42930ce4";

    [JsonPropertyName("api_key")]
    public string ApiKey = "AIzaSyDdIbPOsEp_VvFfdRypzBm_MKGESQZIF_Q";

    [JsonPropertyName("auth_domain")]
    public string AuthDomain = "dienstleistungen-sap.firebaseapp.com";
}

﻿namespace Dienstleistungen_SAP.DataModels;

public class Service
{
    public Service()
    {
    }

    public Service(int id, DateTime creationDate, string plz, string description, string title, string userId)
    {
        Id = id;
        CreationDate = creationDate;
        Plz = plz;
        Description = description;
        Title = title;
        UserId = userId;
    }

    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string Plz { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public string UserId { get; set; }

    public ServiceType Type { get; set; }

    public enum ServiceType
    {
        Offer,
        Request
    }
}

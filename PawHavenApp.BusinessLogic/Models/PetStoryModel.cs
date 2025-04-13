namespace PawHavenApp.BusinessLogic.Models;

using Microsoft.AspNetCore.Http;
using PawHavenApp.DataAccess.Entities;

public class PetStoryModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int Likes { get; set; }

    public string? Link { get; set; }

    public Guid AuthorId { get; set; }

    public UserModel User { get; set; }
}

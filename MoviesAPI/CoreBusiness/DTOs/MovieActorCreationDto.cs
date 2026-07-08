using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.DTOs;

public class MovieActorCreationDto
{
    // ActorId
    public int Id { get; set; }
    
    [StringLength(300)]
    public string? Character { get; set; }
}
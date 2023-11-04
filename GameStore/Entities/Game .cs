using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Entities;

public class Game
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string? Name { get; set; }

    [Required]
    [StringLength(20)]
    public required string? Genre { get; set; }

    [Range(0, 100)]
    public decimal Price { get; set; }
    public DateTime ReliseDate { get; set; }

    public required string ImageUrl { get; set; }



}

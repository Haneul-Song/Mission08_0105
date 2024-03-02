using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_0105.Models;

public partial class Todo
{
    public int TaskId { get; set; }

    public string Task { get; set; } = null!; // "= null!" This randomly created when I scaffolded the database. I am not sure we should leave it or not

    public DateTime? DueDate { get; set; }

    public string Quadrant { get; set; } = null!;
    [ForeignKey("CategoryId")]
    public string? CategoryId { get; set; }

    public int Completed { get; set; }
}


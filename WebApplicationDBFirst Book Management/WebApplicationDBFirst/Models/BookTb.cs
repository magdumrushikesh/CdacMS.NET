using System;
using System.Collections.Generic;

namespace WebApplicationDBFirst.Models;

public partial class BookTb
{
    public int BookId { get; set; }

    public string Bname { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public int UserId { get; set; }

    public virtual UserTb? User { get; set; } = null!;
}

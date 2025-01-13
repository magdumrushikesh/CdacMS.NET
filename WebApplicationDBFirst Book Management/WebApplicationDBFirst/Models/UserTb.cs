using System;
using System.Collections.Generic;

namespace WebApplicationDBFirst.Models;

public partial class UserTb
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<BookTb> BookTbs { get; set; } = new List<BookTb>();
}

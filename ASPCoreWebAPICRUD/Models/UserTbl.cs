using System;
using System.Collections.Generic;

namespace ASPCoreWebAPICRUD.Models;

public partial class UserTbl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Age { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace LapStore.Models;

public partial class TbUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;
}

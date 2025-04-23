using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APPWeb_CRUD.Models;

public partial class CatUserApplication
{
    [Key]
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool UserStatus { get; set; }
}

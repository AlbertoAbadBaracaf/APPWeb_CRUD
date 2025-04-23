using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APPWeb_CRUD.Models;

public partial class LogWebAppWbapiCrud
{
    [Key]
    public int IdLog { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Request { get; set; }

    public string? Response { get; set; }

    public string? Uidd { get; set; }

    public string? Error { get; set; }
}

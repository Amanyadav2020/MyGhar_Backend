using System;
using System.Collections.Generic;

namespace MyGhar_Backend.DBContext;

public partial class Status
{
    public int Id { get; set; }

    public string? Status1 { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }
}

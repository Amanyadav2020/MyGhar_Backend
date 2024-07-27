using System;
using System.Collections.Generic;

namespace MyGhar_Backend.DBContext;

public partial class UserDetail
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string PinCode { get; set; } = null!;

    public string? AccountHolderName { get; set; }

    public string? AccountNumber { get; set; }

    public string? Ifsccode { get; set; }

    public string? Upiid { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual UserMaster User { get; set; } = null!;
}

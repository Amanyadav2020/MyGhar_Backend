using System;
using System.Collections.Generic;

namespace MyGhar_Backend.DBContext;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<UserRoleMatrix> UserRoleMatrices { get; set; } = new List<UserRoleMatrix>();
}

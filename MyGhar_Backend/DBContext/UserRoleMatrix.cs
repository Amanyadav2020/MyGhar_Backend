using System;
using System.Collections.Generic;

namespace MyGhar_Backend.DBContext;

public partial class UserRoleMatrix
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual UserMaster User { get; set; } = null!;
}

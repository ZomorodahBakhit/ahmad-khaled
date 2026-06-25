using System;
using System.Collections.Generic;

namespace Task2.API.Data.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int AssignmentId { get; set; }

    public int CreatedeByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? CommentContent { get; set; }

    public virtual Assignment Assignment { get; set; } = null!;

    public virtual User CreatedeByUser { get; set; } = null!;
}

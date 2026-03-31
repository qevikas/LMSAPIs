namespace CoreWebAPI.Entities
{
    public class BaseEntity
    {
        public bool Active { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? RevisionNumber { get; set; }
        public string? RowVersion { get; set; }
    }
}

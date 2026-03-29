namespace CoreWebAPI.Entities
{
    public class MainMenu: BaseEntity
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public short? Priority { get; set; }
    }
}

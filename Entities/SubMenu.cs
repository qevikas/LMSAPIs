namespace CoreWebAPI.Entities
{
    public class SubMenu : BaseEntity
    {
        public int ID { get; set; }
        public int MainMenuID { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public short? Priority { get; set; }
        public virtual MainMenu MainMenu { get; set; }
    }
}

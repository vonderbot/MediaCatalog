namespace MediaCatalog.BusinessLogic.Dtos
{
    public class UserSettingsDto
    {
        public VideoSettingsDto VideoSettings { get; set; } = new();

        public class VideoSettingsDto
        {
            public string? Directory { get; set; }
            public string? LastOpenedFileName { get; set; }

        }
    }
}

namespace ClassLibrary.Models
{
    public enum Languages
    {
        Croatian, English
    }
    public enum Gender
    {
        Female, Male
    }
    public enum ScreenSize
    {
        Fullscreen,
        Resolution_1024x768,
        Resolution_1280x1024,
        Resolution_1920x1080
    }
    public class InitialSetting
    {
        public Languages SelectedLanguage { get; set; }
        public Gender SelectedGender { get; set; }
        public ScreenSize SelectedScreenSize { get; set; }//ovo makni ako nece radit
    }
}

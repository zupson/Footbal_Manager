using ClassLibrary.Constants;
using ClassLibrary.Dal;
using ClassLibrary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsApp
{
    internal static class Program

    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var initialSettingsRepo = new InitialSettingsRepository();
            var settings = await initialSettingsRepo.LoadFromFile(LocalPaths.InitialSettingsFile);
            string cultureCode = settings.SelectedLanguage switch
            {
                Languages.Croatian => "hr",
                Languages.English =>"en",
                _ => "en"
            };
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureCode);

            ServiceCollection services = new ServiceCollection();
            Application.Run(new BaseForm());
        }
    }
}
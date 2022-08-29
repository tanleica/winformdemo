using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;

namespace WinFormDemo
{
    [RunInstaller(true)]
    public class DemoInstallerClass: Installer
    {
        public DemoInstallerClass(): base()
        {
        }

        public override void Install(IDictionary savedState)
        {
            base.Install(savedState);

            string executingAssemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Configuration config = ConfigurationManager.OpenExeConfiguration(executingAssemblyLocation);
            string provider = "DataProtectionConfigurationProvider";
            ConfigurationSection connstrings = config.ConnectionStrings;
            if (!connstrings.SectionInformation.IsProtected)
            {
                connstrings.SectionInformation.ProtectSection(provider);
            }
            connstrings.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using QSP.LibraryExtension;

namespace QSP
{
    public class AppOptions
    {

        public string NavDBLocation { get; set; }
        public bool PromptBeforeExit { get; set; }
        public bool AutoDLTracks { get; set; }
        public bool AutoDLWind { get; set; }
        public List<RouteExportCommand> ExportCommands { get; set; }

        public AppOptions()
        {
            ExportCommands = new List<RouteExportCommand>();
        }


        public AppOptions(XDocument xmlFile)
        {
            var root = xmlFile.Root;

            NavDBLocation = root.Element("DatabasePath").Value ;
            PromptBeforeExit = root.Element("PromptBeforeExit").ToBool();
            AutoDLTracks = root.Element("AutoDLNats").ToBool();
            AutoDLWind = root.Element("AutoDLWind").ToBool();

            var exports = root.Element("ExportOptions");

            ExportCommands = new List<RouteExportCommand>();

            foreach (var i in exports.Elements())
            {
                ExportCommands.Add(new RouteExportCommand(i.Name.LocalName,
                   i.Element("Path").Value, i.Element("Enabled").ToBool()));
            }

        }

        public XElement ToXml()
        {
            XElement[] exports = new XElement[ExportCommands.Count];

            for (int i = 0; i <= ExportCommands.Count - 1; i++)
            {
                var command = ExportCommands[i];
                exports[i] = new XElement(command.Format, new XElement[] {
                    new XElement("Enabled", Convert.ToString(command.Enabled)),
                    new XElement("Path", command.FilePath)
                });
            }

            var exportOptions = new XElement("ExportOptions", exports);

            return new XElement("AppOptions", new XElement[] {
                new XElement("DatabasePath", NavDBLocation),
                new XElement("PromptBeforeExit", Convert.ToString(PromptBeforeExit)),
                new XElement("AutoDLNats", Convert.ToString(AutoDLTracks)),
                new XElement("AutoDLWind", Convert.ToString(AutoDLWind)),
                exportOptions
            });

        }

        public RouteExportCommand GetExportCommand(string format)
        {
            foreach (var i in ExportCommands)
            {
                if (i.Format == format)
                {
                    return i;
                }

            }
            return null;
        }

    }

    public class RouteExportCommand
    {
        public string Format { get; set; }
        public string FilePath { get; set; }
        public bool Enabled { get; set; }

        public RouteExportCommand(string Format, string FilePath, bool Enabled)
        {
            this.Format = Format;
            this.FilePath = FilePath;
            this.Enabled = Enabled;
        }
    }
}

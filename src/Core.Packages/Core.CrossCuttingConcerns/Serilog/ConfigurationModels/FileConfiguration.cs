using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Serilog.ConfigurationModels
{
    public class FileConfiguration
    {
        public string FolderPath { get; set; }

        public FileConfiguration()
        {
            FolderPath = string.Empty;
        }

        public FileConfiguration(string folderPath)
        {
            FolderPath = folderPath;
        }
    }
}

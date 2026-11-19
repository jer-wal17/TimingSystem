using System.ComponentModel.DataAnnotations;

namespace TimingSystem.Library.Tables
{
    public class Driver
    {
        [Key]
        public int DriverKey { get; set; }

        public string Name { get; set; } = "";

        public int Number { get; set; }

        public string Class { get; set; } = "";
    }
}

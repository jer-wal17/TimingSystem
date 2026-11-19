using System.ComponentModel.DataAnnotations;

namespace TimingSystem.Library.Tables
{
    public class Time
    {
        [Key]
        public int TimesKey { get; set; }

        public int DriverKey { get; set; }

        public int Time_Ms { get; set; }

        public int Cones { get; set; }

        public bool Dnf { get; set; }
    }
}

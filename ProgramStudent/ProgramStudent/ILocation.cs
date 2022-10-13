using System;
namespace ProgramStudent
{
    public interface ILocation
    {
        public static readonly TimeSpan OPENINGOUR;
        public static readonly TimeSpan CLOSINGHOUR;
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public void Hub(Player player);
        

    }
}

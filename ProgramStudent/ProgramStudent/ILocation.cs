namespace ProgramStudent
{
    public interface ILocation
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public void Hub(Player player);
    }
}

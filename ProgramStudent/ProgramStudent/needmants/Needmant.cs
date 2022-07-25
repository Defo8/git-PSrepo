namespace ProgramStudent
{
    public abstract class Needmant
    {
        public int Modifier { get; set; }
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }
        public string Name { get; set; }
        public int TokenOfZero { get; set; }
        public abstract void Increase(int amount);
        public abstract void Decrease(int amount);
        public abstract void IfCurrentValueZero();
    }
}

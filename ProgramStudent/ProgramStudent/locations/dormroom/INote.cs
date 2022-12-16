namespace ProgramStudent
{
    public interface INote
    {
        public string Name { get; set; }
        public int KnowledgeValue { get; set; }
        public int LearnProgress { get; set; }
        public int MakeingProgress { get; set; }
        public void WorkOnIt(Player player);
        public void LearnFromIt(Player player);
    }
}

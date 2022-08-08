namespace Exam.Data.Entries
{
    public class MaterialType
    {
        public int MaterialTypeId { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public IEnumerable<Material> Materials { get; set; }
    }
}
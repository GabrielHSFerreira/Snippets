namespace EF6OnCore
{
    public class Entity
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id} - {Value}";
        }
    }
}
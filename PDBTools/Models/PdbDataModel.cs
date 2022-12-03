namespace PDBTools.Models
{
    public class PdbDataModel
    {
        public List<Model>? Models { get; set; }
    }

    public class Model
    {
        public string Id { get; set; }
        public List<Atom>? Atoms { get; set; }
    }

    public class Atom
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public string Type { get; set; }
    }
}

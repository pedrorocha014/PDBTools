﻿namespace PDBTools.Models
{
    public class PdbDataModel
    {
        public List<Model>? Models { get; set; }
    }

    public class Model
    {
        public string Id { get; set; }
        public List<Atom>? Atom { get; set; }
        public List<Anisou>? Anisou { get; set; }
        public List<Hetatm>? Hetatm { get; set; }
        public List<Ter>? Ter { get; set; }
    }

    public class Atom
    {
        public int Serial { get; set; }
        public string Name { get; set; }
        public string AltLoc { get; set; }
        public string ResName { get; set; }
        public string ChainID { get; set; }
        public int ResSeq { get; set; }
        public string ICode { get; set; }         
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public string Occupancy { get; set; }
        public string TempFactor { get; set; }
        public string Element { get; set; }
        public string Charge { get; set; }
    }

    public class Anisou{

    }

    public class Hetatm{

    }

    public class Ter{
        public int Serial { get; set; }
        public string ResName { get; set; }
        public string ChainId { get; set; }
        public int ResSeq { get; set; }
        public string ICode { get; set; }
    }
}
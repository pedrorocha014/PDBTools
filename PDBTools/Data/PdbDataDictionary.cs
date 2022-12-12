namespace PDBTools.Data
{
    public static class PdbDataDictionary
    {
        public static IDictionary<string, Func<string, string>> Model = new Dictionary<string, Func<string, string>>()
        {
            { "ID", (line) => GetDataFromString(line, 10, 4) }
        };

        public static IDictionary<string, Func<string, string>> Atom = new Dictionary<string, Func<string, string>>()
        {
            { "SERIAL"     , (line) => GetDataFromString(line, 6, 5) },
            { "NAME"       , (line) => GetDataFromString(line, 12, 4) },
            { "ALTLOC"     , (line) => GetDataFromString(line, 16, 1) },
            { "RESNAME"    , (line) => GetDataFromString(line, 17, 3) },
            { "CHAINID"    , (line) => GetDataFromString(line, 21, 1) },
            { "RESSEQ"     , (line) => GetDataFromString(line, 22, 4) },
            { "ICODE"      , (line) => GetDataFromString(line, 26, 1) },
            { "X"          , (line) => GetDataFromString(line, 30, 8) },
            { "Y"          , (line) => GetDataFromString(line, 38, 8) },
            { "Z"          , (line) => GetDataFromString(line, 46, 8) },
            { "OCCUPANCY"  , (line) => GetDataFromString(line, 54, 6) },
            { "TEMPFACTOR" , (line) => GetDataFromString(line, 60, 6) },
            { "ELEMENT"    , (line) => GetDataFromString(line, 76, 2) },
            { "CHARGE"     , (line) => GetDataFromString(line, 78, 2) }
        };

        public static IDictionary<string, Func<string, string>> Anisou = new Dictionary<string, Func<string, string>>()
        {
            { "SERIAL"     , (line) => GetDataFromString(line, 1, 1) },
            { "NAME"       , (line) => GetDataFromString(line, 1, 1) },
            { "ALTLOC"     , (line) => GetDataFromString(line, 1, 1) },
            { "RESNAME"    , (line) => GetDataFromString(line, 1, 1) },
            { "CHAINID"    , (line) => GetDataFromString(line, 1, 1) },
            { "RESSEQ"     , (line) => GetDataFromString(line, 1, 1) },
            { "ICODE"      , (line) => GetDataFromString(line, 1, 1) },
            { "U_00"       , (line) => GetDataFromString(line, 1, 1) },
            { "U_11"       , (line) => GetDataFromString(line, 1, 1) },
            { "U_22"       , (line) => GetDataFromString(line, 1, 1) },
            { "U_01"       , (line) => GetDataFromString(line, 1, 1) },
            { "U_02"       , (line) => GetDataFromString(line, 1, 1) },
            { "U_12"       , (line) => GetDataFromString(line, 1, 1) },
            { "ELEMENT"    , (line) => GetDataFromString(line, 1, 1) },
            { "CHARGE"     , (line) => GetDataFromString(line, 1, 1) }
        };

        public static IDictionary<string, Func<string, string>> Hetatm = new Dictionary<string, Func<string, string>>()
        {
            { "SERIAL"     , (line) => GetDataFromString(line, 1, 1) },
            { "NAME"       , (line) => GetDataFromString(line, 1, 1) },
            { "ALTLOC"     , (line) => GetDataFromString(line, 1, 1) },
            { "RESNAME"    , (line) => GetDataFromString(line, 1, 1) },
            { "CHAINID"    , (line) => GetDataFromString(line, 1, 1) },
            { "RESSEQ"     , (line) => GetDataFromString(line, 1, 1) },
            { "ICODE"      , (line) => GetDataFromString(line, 1, 1) },
            { "X"          , (line) => GetDataFromString(line, 1, 1) },
            { "Y"          , (line) => GetDataFromString(line, 1, 1) },
            { "Z"          , (line) => GetDataFromString(line, 1, 1) },
            { "OCCUPANCY"  , (line) => GetDataFromString(line, 1, 1) },
            { "TEMPFACTOR" , (line) => GetDataFromString(line, 1, 1) },
            { "ELEMENT"    , (line) => GetDataFromString(line, 1, 1) },
            { "CHARGE"     , (line) => GetDataFromString(line, 1, 1) }
        };

        public static IDictionary<string, Func<string, string>> Ter = new Dictionary<string, Func<string, string>>()
        {
            { "SERIAL"     , (line) => GetDataFromString(line, 6, 5) },
            { "RESNAME"    , (line) => GetDataFromString(line, 17, 3) },
            { "CHAINID"    , (line) => GetDataFromString(line, 21, 1) },
            { "RESSEQ"     , (line) => GetDataFromString(line, 22, 4) },
            { "ICODE"      , (line) => GetDataFromString(line, 26, 1) }
        };

        private static string GetDataFromString(string line, int startIndex, int length) => line.Substring(startIndex, length).Trim();
    }
}

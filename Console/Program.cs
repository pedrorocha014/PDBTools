using PDBTools.Serializer;

List<string> lines = File.ReadAllLines("/home/pedro/Downloads/2m6q(1).pdb").ToList();  

var result = PDBSerializer.Serialize(lines);

Console.WriteLine(result.Models);

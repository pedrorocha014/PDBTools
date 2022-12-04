using PDBTools.Serializer;

var dataList = new List<string>();

List<string> lines = File.ReadAllLines("/home/pedro/Downloads/2m6q(1).pdb").ToList();  

var a = new PDBSerializer();

var result = a.Serialize(dataList);

Console.WriteLine(result.Models);

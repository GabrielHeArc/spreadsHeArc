using Newtonsoft.Json;
using spreadsHeArc.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace spreadsHeArc.Model
{
    public class SaveData : Model
    {
        static string jsonString;
        static JsonSerializer serializer = new JsonSerializer();

        public static void Export()
        {
            using (var streamWriter = new StreamWriter("data.json"))
            {
                using (var jsonWriter = new JsonTextWriter(streamWriter))
                {
                    {
                        jsonString = JsonConvert.SerializeObject(BranchViewModel.GetInstance().ListBranches, Formatting.Indented);
                        jsonWriter.Formatting = Formatting.Indented;
                        serializer.Serialize(jsonWriter, JsonConvert.DeserializeObject(jsonString));
                    }
                }
            }
        }

        public static void Import()
        {
            using (var streamReader = new StreamReader("data.json"))
            {
                using (var jsonReader = new JsonTextReader(streamReader))
                {

                    var branches = serializer.Deserialize<List<Branch>>(jsonReader);
                    foreach (var branch in branches)
                    {
                        //Console.WriteLine(branch.Module.NameModule);
                        Module newModule = new Module(branch.Module.NameModule);
                        Branch newBranch = new Branch(branch.NameBranch, branch.WeightBranch, newModule);

                        ModuleViewModel.GetInstance().ListModules.Add(newModule); //TODO assurer unicité module (ou pas ?)
                        newModule.ListBranch.Add(newBranch);
                        BranchViewModel.GetInstance().ListBranches.Add(newBranch);

                        foreach (var rating in branch.ListRate)
                        {
                            Rating newRate = new Rating(rating.Mark, rating.WeightMark);
                            BranchViewModel.GetInstance().AddRating(newBranch, newRate);
                        }
                    }
                }
            }
        }
    }
}

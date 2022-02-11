using Newtonsoft.Json;
using spreadsHeArc.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                    jsonString = JsonConvert.SerializeObject(ModuleViewModel.GetInstance().ListModules, Formatting.Indented);
                    jsonWriter.Formatting = Formatting.Indented;                    
                    serializer.Serialize(jsonWriter, JsonConvert.DeserializeObject(jsonString));
                }
            }
        }

        public static void Import()
        {
            using (var streamReader = new StreamReader("data.json"))
            {
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var modules = serializer.Deserialize<List<Module>>(jsonReader);

                    foreach (var module in modules)
                    {
                        Module newModule = new Module(module.NameModule);
                        ModuleViewModel.GetInstance().ListModules.Add(newModule);

                        foreach (var branch in module.ListBranch)
                        {
                            Branch newBranch = BranchViewModel.GetInstance().AddBranch(branch.NameBranch, branch.WeightBranch, newModule);
                            

                            foreach(var rating in branch.ListRate)
                            {
                                Rating newRating = new Rating(rating.Mark, rating.WeightMark);
                                BranchViewModel.GetInstance().AddRating(newBranch, newRating);
                            }
                        }
                    }




                    //var branches = JsonConvert.DeserializeObject
                    //List<Branch> branches = serializer.Deserialize<List<Branch>>(jsonReader);                    
                    /*
                    foreach (Branch branch in branches)
                    {
                        MessageBox.Show(branch.NameBranch);
                        //Branch newBranch = new Branch(branch.NameBranch, branch.WeightBranch, branch.Module);
                        //Module newModule = ModuleViewModel.GetInstance().TryAdd(newBranch.Module.NameModule);
                        Module newModule = ModuleViewModel.GetInstance().TryAdd(branch.Module.NameModule);
                        //BranchViewModel.GetInstance().AddBranch(newBranch.NameBranch, newBranch.WeightBranch, newModule);
                        BranchViewModel.GetInstance().AddBranch(branch.NameBranch, branch.WeightBranch, newModule);                                               

                        foreach (Rating rating in branch.ListRate)
                        {
                            MessageBox.Show(rating.ToString());
                            Rating newRating = new Rating(rating.Mark, rating.WeightMark);
                            BranchViewModel.GetInstance().AddRating(branch, newRating);
                        }
                    }*/
                }
            }
        }
    }
}

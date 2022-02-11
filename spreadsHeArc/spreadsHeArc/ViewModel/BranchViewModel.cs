﻿using spreadsHeArc.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace spreadsHeArc.ViewModel
{
    /// <summary>
    /// BranchViewModel is designed with Singleton pattern. It references all branches of all modules in list
    /// </summary>
    public class BranchViewModel : ViewModel
    {
        /// <summary>
        /// Private constructor due to Singleton pattern.
        /// </summary>
        private BranchViewModel()
        {
        }

        /// <summary>
        /// Getter of BranchViewModel single instance.
        /// </summary>
        /// <returns>BranchViewModel instance</returns>
        public static BranchViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new BranchViewModel();
            return _instance;
        }

        private static BranchViewModel _instance;

        public List<Branch> ListBranches { get; set; } = new List<Branch>();

        /// <summary>
        /// AddBranch adds a just created branch in list of branch in its module.
        /// </summary>
        /// <param name="name">Name of new branch</param>
        /// <param name="weight">Weight of new branch in module</param>
        /// <param name="module">Module instance of branch</param>
        public Branch AddBranch(string name, int weight, Module module)
        {
            Branch newBranch = new Branch(name, weight, module);
            ListBranches.Add(newBranch);
            try
            {                             
                module.ListBranch.Add(newBranch);
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur : Aucun module n'est renseigné");
            }

            return newBranch;
        }

        /// <summary>
        /// AddRating adds new rating instance in list of rates on appropriate branch.
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="rating"></param>
        public void AddRating(Branch branch, Rating rating)
        {
            int length = branch.ListRate.Count;
            
            branch.ListRate.Add(rating);            
            branch.ProcessAverage();
            branch.Module.ProcessAverage();            
        }
    }
}

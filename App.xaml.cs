using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LibGit2Sharp;
using System.Diagnostics;

namespace MineCraftServerSubvers
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //todo: Research best place to put logic in wpf apps
        public App()
        {
            using (var repo = new Repository(@"..\..\..\..\MinecraftServer"))
            {
                var branches = repo.Branches;
                foreach(var b in branches)
                {
                    Trace.WriteLine(b.FriendlyName);
                    
                }

                foreach(var commit in repo.Commits)
                {
                    Trace.WriteLine(
                        $"{commit.Id.ToString().Substring(0, 7)} " +
                        $"{commit.Author.When.ToLocalTime()} " +
                        $"{commit.MessageShort} " +
                        $"{commit.Author.Name}");
                    
                }
                repo.Network.Fetch("origin", null); //cant be null require credentials 

                
            }
        }

    }
}

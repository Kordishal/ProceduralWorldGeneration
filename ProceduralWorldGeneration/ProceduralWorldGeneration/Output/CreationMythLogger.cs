using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Utility;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ProceduralWorldGeneration.Output
{
    /// <summary>
    /// Creates three different logs of the creation process.
    /// </summary>
    class CreationMythLogger
    {
        static public StreamWriter writer;

        static private List<string> _temp_log = new List<string>();
        static private List<string> _action_log = new List<string>();
        static private List<string> _tree_log = new List<string>();

        private const string BaseLogDirectoryPath = @"C:\Users\jwaeb\Documents\Projects\UniverseGeneration\logs";

        public CreationMythLogger()
        {
            Debug.Assert(Directory.Exists(BaseLogDirectoryPath));

        }

        static public void Clear()
        {
            _temp_log.Clear();
            _action_log.Clear();
            _tree_log.Clear();
        }

        static public void Write()
        {
            writer = new StreamWriter(BaseLogDirectoryPath + Constants.FileNames.MYTHCREATION_LOG);
            foreach (string s in _temp_log)
            {
                writer.WriteLine(s);
            }         
            writer.Close();

            writer = new StreamWriter(BaseLogDirectoryPath + Constants.FileNames.ACTION_LOG);
            foreach (string s in _action_log)
            {
                writer.WriteLine(s);
            }
            writer.Close();

            writer = new StreamWriter(BaseLogDirectoryPath + Constants.FileNames.CREATION_TREE_LOG);
            foreach (string s in _tree_log)
            {
                writer.WriteLine(s);
            }
            writer.Close();
        }

        static public void AppendWrite()
        {
            writer = new StreamWriter(BaseLogDirectoryPath + Constants.FileNames.MYTHCREATION_LOG, true);
            foreach (string s in _temp_log)
            {
                writer.WriteLine(s);
            }
            writer.Close();

            writer = new StreamWriter(BaseLogDirectoryPath + Constants.FileNames.ACTION_LOG, true);
            foreach (string s in _action_log)
            {
                writer.WriteLine(s);
            }
            writer.Close();

            writer = new StreamWriter(BaseLogDirectoryPath + Constants.FileNames.CREATION_TREE_LOG, true);
            foreach (string s in _tree_log)
            {
                writer.WriteLine(s);
            }
            writer.Close();
        }

        static public void UpdateLog(string line)
        {
            _temp_log.Add(line);
        }

        static public void UpdateLog(BaseMythObject myth_object, string action)
        {
            _temp_log.Add(action + ": " + myth_object.ToString());
        }

        static public void UpdateLog(int current_year)
        {
            _temp_log.Add("YEAR: " + current_year);
        }

        static public void UpdateActionLog(ActionTakerMythObject myth_object)
        {
            _action_log.Add(myth_object.Name + " is taking " + myth_object.CurrentAction.ToString() + " to reach current goal: " + myth_object.CurrentGoal.ToString());
            
        }

        static public void UpdateActionLog(ActionTakerMythObject myth_object, bool action_finished)
        {
            if (myth_object.CurrentAction == null)
            {
                _action_log.Add(myth_object.Name + " has reached the following goal: " + myth_object.CurrentGoal.ToString());
            }
            else
            {
                _action_log.Add(myth_object.Name + " has taken " + myth_object.CurrentAction.ToString() + " and reached: " + myth_object.CurrentGoal.ToString());
            }

        }

        static public void UpdateActionLog(string line)
        {
            _action_log.Add(line);
        }

        static public void UpdateTreeLog(TreeNode<CreationTreeNode> node)
        {
            string child_names = "";

            foreach (TreeNode<CreationTreeNode> n in node.Children)
            {
                child_names += n.ToString();
            }

            _tree_log.Add(node.ToString() + ": " + child_names);
        }
    }
}

using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Parser.SyntaxTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Output
{
    class CreationMythLogger
    {
        static public StreamWriter writer;

        static private List<string> _temp_log = new List<string>();
        static private List<string> _action_log = new List<string>();
        static private List<string> _tree_log = new List<string>();

        public CreationMythLogger()
        {


        }

        static public void Clear()
        {
            _temp_log.Clear();
            _action_log.Clear();
            _tree_log.Clear();
        }

        static public void Write()
        {
            writer = new StreamWriter(@"C:\Users\Jonas\Documents\ProceduralWorldGeneration\logs\myth_creation.log");
            foreach (string s in _temp_log)
            {
                writer.WriteLine(s);
            }         
            writer.Close();

            writer = new StreamWriter(@"C:\Users\Jonas\Documents\ProceduralWorldGeneration\logs\action.log");
            foreach (string s in _action_log)
            {
                writer.WriteLine(s);
            }
            writer.Close();

            writer = new StreamWriter(@"C:\Users\Jonas\Documents\ProceduralWorldGeneration\logs\tree.log");
            foreach (string s in _tree_log)
            {
                writer.WriteLine(s);
            }
            writer.Close();
        }

        static public void AppendWrite()
        {
            writer = new StreamWriter(@"C:\Users\Jonas\Documents\ProceduralWorldGeneration\logs\myth_creation.log",true);
            foreach (string s in _temp_log)
            {
                writer.WriteLine(s);
            }
            writer.Close();

            writer = new StreamWriter(@"C:\Users\Jonas\Documents\ProceduralWorldGeneration\logs\action.log", true);
            foreach (string s in _action_log)
            {
                writer.WriteLine(s);
            }
            writer.Close();

            writer = new StreamWriter(@"C:\Users\Jonas\Documents\ProceduralWorldGeneration\logs\tree.log", true);
            foreach (string s in _tree_log)
            {
                writer.WriteLine(s);
            }
            writer.Close();
        }

        static public void updateLog(string line)
        {
            _temp_log.Add(line);
        }

        static public void updateLog(BaseMythObject myth_object, string action)
        {
            _temp_log.Add(action + ": " + myth_object.ToString());
        }

        static public void updateLog(int current_year)
        {
            _temp_log.Add("YEAR: " + current_year);
        }

        static public void updateActionLog(ActionTakerMythObject myth_object)
        {
            if (myth_object.CurrentAction == null)
            {
                _action_log.Add(myth_object.Name + " is taking no action to reach current goal: " + myth_object.CurrentGoal.ToString());
            }
            else
            {
                _action_log.Add(myth_object.Name + " is taking " + myth_object.CurrentAction.ToString() + " to reach current goal: " + myth_object.CurrentGoal.ToString());
            }
            
        }

        static public void updateActionLog(ActionTakerMythObject myth_object, bool action_finished)
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

        static public void updateActionLog(string line)
        {
            _action_log.Add(line);
        }

        static public void updateTreeLog(TreeNode<CreationTreeNode> node)
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

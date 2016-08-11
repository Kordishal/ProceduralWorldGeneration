using ProceduralWorldGeneration.Constants;
using ProceduralWorldGeneration.Parser.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser
{
    class MythObjectReader : INotifyPropertyChanged
    {
        MythCreationLexer Lexer = new MythCreationLexer();

        private List<Token> _tokens;
        public List<Token> Tokens
        {
            get
            {
                return _tokens;
            }
            set
            {
                if (value != _tokens)
                {
                    _tokens = value;
                    this.NotifyPropertyChanged("Tokens");
                }
            }
        }

        public MythObjectReader()
        {

        }

        public void readMythObjects()
        {
            List<string> file_names = readFileNames();
            Tokens = new List<Token>();

            foreach (string file in file_names)
            {
                Tokens.AddRange(Lexer.GetTokens(FileNames.DIRECTORY_PATH_MYTH_OBJECTS + file));               
            }           
        }

        List<string> readFileNames()
        {
            List<string> file_names = new List<string>();
            StreamReader reader = new StreamReader(FileNames.DIRECTORY_PATH_MYTH_OBJECTS + FileNames.FILE_LIST);

            while (!reader.EndOfStream)
            {
                file_names.Add(reader.ReadLine());
            }

            reader.Close();

            return file_names;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


    }
}

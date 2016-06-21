using ProceduralWorldGeneration.Input.LexerDefinition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Input
{
    class MythObjectReader : INotifyPropertyChanged
    {
        MythCreationLexer Lexer = new MythCreationLexer();

        private IEnumerable<Token> _tokens;
        public IEnumerable<Token> Tokens
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
            Tokens = Lexer.GetTokens(FileNames.DIRECTORY_PATH_MYTH_OBJECTS + FileNames.PRIMORDIAL_FORCES);

        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


    }
}

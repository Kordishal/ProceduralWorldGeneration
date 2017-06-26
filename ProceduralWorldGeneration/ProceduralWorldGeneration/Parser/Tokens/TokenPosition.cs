﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser.Tokens
{
    /// <summary>
    /// Stores the position of a token in the files read. Not actually clear what the individual values mean.
    /// </summary>
    public class TokenPosition
    {
        public int Column { get; set; }
        public int Index { get; set; }
        public int Line { get; set; }

        public TokenPosition(int c, int i, int l)
        {
            Column = c;
            Index = i;
            Line = l;
        }

        public override string ToString()
        {
            return "Line: " + Line.ToString() + " ; Column: " + Column.ToString() + " ; Index: " + Index.ToString();
        }
    }
}

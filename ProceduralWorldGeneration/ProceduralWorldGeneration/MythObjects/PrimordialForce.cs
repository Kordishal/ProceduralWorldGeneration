﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjects
{
    class PrimordialForce : BaseMythObject, IAction
    {
        public static string TYPE = "PRIMORDIALPOWER";


        private string _opposing;
        public string Opposing
        {
            get
            {
                return _opposing;
            }
            set
            {
                if (_opposing != value)
                {
                    _opposing = value;
                    base.NotifyPropertyChanged("Opposing");
                }
            }
        }

        public PrimordialForce() : base()
        {
            base.Type = TYPE;
        }




        public void takeAction()
        {
            throw new NotImplementedException();
        }
    }
}
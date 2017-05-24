﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class InformationViewModel : ViewModel
    {
        private InformationModel model;
        public InformationViewModel()
        {
            this.model = new InformationModel();
        }

        public string Name
        {
            get { return model.Name; }
            set
            {
                model.Name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public int Colomns
        {
            get { return model.Colomns; }
            set
            {
                model.Colomns = value;
                NotifyPropertyChanged("Colomns");
            }
        }

        public int Rows
        {
            get { return model.Rows; }
            set
            {
                model.Rows = value;
                NotifyPropertyChanged("Rows");
            }
        }

        public void SaveSettings()
        {
            model.SaveChanges();
        }
    }
}
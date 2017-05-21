using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class MultyPlayerVM : ViewModel
    {
        private MultyPlayerModel model;
        public MultyPlayerVM()
        {
            this.model = new MultyPlayerModel();
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

        public string VM_list
        {
            get
            {
                return this.model.list;
            }
            set
            {
                model.list = value;
                NotifyPropertyChanged("list");

            }
        }


        public void SaveSettings()
        {
            model.SaveChanges();
        }

        public void start(Client client)
        {
            model.start(client);
        }

        public string join(Client client)
        {
            return model.join(client);
        }

        public string ListStart()
        {
            return model.ListStart();
        }
    }
}

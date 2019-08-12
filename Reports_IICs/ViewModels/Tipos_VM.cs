using Reports_IICs.DataAccess.Tipos;
using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace Reports_IICs.ViewModels
{
    class Tipos_VM : ViewModelBase
    {
        public Tipos_VM()
        {
            this.DataItems = Tipos_DA.GetAll().ToList();
        }

        public List<Tipos> DataItems { get; private set; }
    }
}

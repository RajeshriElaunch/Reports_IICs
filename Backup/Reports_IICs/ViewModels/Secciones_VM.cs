using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using System.Collections.Generic;

namespace Reports_IICs.ViewModels
{
    public class Secciones_VM
    {
        
       
        public Secciones_VM()
        {
            this.DataItems = Secciones_DA.GetAll();
        }

        public List<Seccione> DataItems { get; private set; }
    }
}

using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.DataModels;
using System.Collections.Generic;

namespace Reports_IICs.ViewModels.Plantillas
{
    class PlantillaDetalle_VM
    {
        public static void GuardarPlantilla(Plantilla plantilla)
        {
            Plantillas_DA.GuardarPlantilla(plantilla);
        }
    }
}

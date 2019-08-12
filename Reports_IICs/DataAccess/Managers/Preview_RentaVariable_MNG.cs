using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Collections.Generic;

namespace Reports_IICs.DataAccess.Managers
{
    class Preview_RentaVariable_MNG : BaseManagers<RentaVariable_PrecioAjustado>
    {
        public IEnumerable<object> GetByCodigoIC(string codigoIC, bool? previewNew = null)
        {
            IEnumerable<object> output = GetAll(x =>
                    x.CodigoIC == codigoIC);

            return output;
        }
    }
}

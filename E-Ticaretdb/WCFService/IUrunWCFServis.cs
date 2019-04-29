using E_Ticaretdb.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaretdb.WCFService
{
    [ServiceContract]
   public interface IUrunWCFServis
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        List<Urunler> List();
    }
}

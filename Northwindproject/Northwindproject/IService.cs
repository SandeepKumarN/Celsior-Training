using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwindproject
{
    internal interface IService
    {
        public bool Login();
        public void Register();
        public void ViewPreviousOrder(string customerId);
        public void ViewOrderSummary();
        public void ViewShippersDetail();
        public void updatePassword();
    }
}

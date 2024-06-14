using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.PaymentProcessos
{
    public class ProcessPayment : IProcessPayment
    {
        public bool PaymentProcessor()
        {
            return true;
        }
    }
}

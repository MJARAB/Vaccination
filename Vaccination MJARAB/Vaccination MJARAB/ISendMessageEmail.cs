using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    interface ISendMessageEmail
    {
        void SendMessage(string to, string body);
    }
}

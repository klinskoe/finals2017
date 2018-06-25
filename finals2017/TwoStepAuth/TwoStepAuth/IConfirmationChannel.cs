using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoStepAuth {
    interface IConfirmationChannel {
        void SendConfirmationCode(User user, string code);
    }
}

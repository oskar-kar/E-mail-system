using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasaSerwera
{
    enum LoginState
    {
        UNVERIFIED,
        LOGGED,
        WANTS_TO_LOGIN,
        WANTS_TO_CREATE_USER,
        INVALID_AUTENTICATION
    }
}

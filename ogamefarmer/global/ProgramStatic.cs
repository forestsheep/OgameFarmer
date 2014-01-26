using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class ProgramStatic
    {
        internal const string AES_PW = "alakazankazankazan";
        internal const string AES_SALT = "blacksheepwall";
        // can be "MD5" or "SHA1"
        internal const string HASH_ALGORITHM = "MD5";
        // can be any number
        internal const int PASSWORD_ITERATIONS = 77;
        // must be 16 bytes
        internal const string INITVECTOR = "Y78iv0%yZP8(kI&U";
        // can be 192 or 128
        internal const int KEY_SIZE = 256; 

        internal const int MAX_DEFENCE_TOWER_NUMBER_IN_ONCE_REQUEST = 5000;
        internal static LoginForm LOGIN_FORM;
    }
}

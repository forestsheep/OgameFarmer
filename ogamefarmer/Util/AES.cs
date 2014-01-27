using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class AES
    {
        internal static string Encrypt(string plainText)
        {
            return Rijndael.Encrypt
            (
                plainText,
                ProgramStatic.AES_PW,
                ProgramStatic.AES_SALT,
                ProgramStatic.HASH_ALGORITHM,
                ProgramStatic.PASSWORD_ITERATIONS,
                ProgramStatic.INITVECTOR,
                ProgramStatic.KEY_SIZE
            );
        }

        internal static string Decrypt(string plainText)
        {
            return Rijndael.Decrypt
            (
                plainText,
                ProgramStatic.AES_PW,
                ProgramStatic.AES_SALT,
                ProgramStatic.HASH_ALGORITHM,
                ProgramStatic.PASSWORD_ITERATIONS,
                ProgramStatic.INITVECTOR,
                ProgramStatic.KEY_SIZE
            );
        }

        internal static string Encrypt(string plainText, string pw, string salt)
        {
            return Rijndael.Encrypt
            (
                plainText,
                pw,
                salt,
                ProgramStatic.HASH_ALGORITHM,
                ProgramStatic.PASSWORD_ITERATIONS,
                ProgramStatic.INITVECTOR,
                ProgramStatic.KEY_SIZE
            );
        }

        internal static string Decrypt(string plainText, string pw, string salt)
        {
            return Rijndael.Decrypt
            (
                plainText,
                pw,
                salt,
                ProgramStatic.HASH_ALGORITHM,
                ProgramStatic.PASSWORD_ITERATIONS,
                ProgramStatic.INITVECTOR,
                ProgramStatic.KEY_SIZE
            );
        }
    }
}

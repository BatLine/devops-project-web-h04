using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Admin:Gebruiker
    {
        public Admin(string gebruikersnaam, DateTime geboortedatum, string email,string fotoPad):base(gebruikersnaam, geboortedatum, email, fotoPad)
        {

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_mafia_in_console_app
{
    internal class Role
    {
        public Role(string Name, string Role)
        {
            PlayerName = Name;
            RoleName = Role;
            Inqury = false;
            InGame = true;
            RoleValue = false;

        }
        public string RoleName;
        public bool RoleValue;
        public bool Inqury;
        public string PlayerName;
        public bool InGame;
    }
}

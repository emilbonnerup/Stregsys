using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class StregsystemCommandParser
    {
        public Stregsystem stregsystem;
        public StregsystemCLI cli;


        public StregsystemCommandParser(Stregsystem stregsystem, StregsystemCLI cli)
        {
            this.stregsystem = stregsystem;
            this.cli = cli;
        }

        public void ParseCommand(string command)
        {
            var commandParts = command.Split(' ');
            if (string.IsNullOrEmpty(commandParts[1]))
            {
                foreach (var user in stregsystem.Users)
                {
                    if (string.Equals(commandParts[0], user.UserName))
                    {
                        cli.DisplayUserInfo(user);
                    }
                }
            }

        }
    }
}

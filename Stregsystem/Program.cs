﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var u = new User(1, "Emil", "Bønnerup", "emilbonnerup", "emilbonnerup@me.com", 100);
            List<User> uList = new List<User>();
            uList.Add(u);
            
        }
    }
}

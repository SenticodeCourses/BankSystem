﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnion.BankSystem.BusinessLogic.Authorization
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public AccountType TypeAccount { get; set; }
        
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Entities;

namespace DeratControl.Application.Requests.Interfaces
{
    public class CommandExecutionContext
    {
        public User requestedUser { get; set; }
    }
}

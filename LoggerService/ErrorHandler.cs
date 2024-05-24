﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    internal class ErrorHandler
    {
        public static void HandleError(Exception exception)
        {
            Console.WriteLine($"An error occurred: {exception.Message}");
        }

    }
}

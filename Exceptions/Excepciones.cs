using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca_Softek.Exceptions
{
    public class Excepciones:Exception
    {
        public Excepciones(string message) : base(message) {}
    }
}
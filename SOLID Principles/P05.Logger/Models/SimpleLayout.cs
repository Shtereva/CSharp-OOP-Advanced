using System;
using P05.Logger.Contracts;

namespace P05.Logger.Models
{
    public class SimpleLayout : ILayout
    {
        public string MessageFormat => "{0} - {1} - {2}";
    }
}

using System;
using P05.Logger.Contracts;
using P05.Logger.Models;

namespace P05.Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout Create(string layoutType)
        {
            switch (layoutType)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
            }

            throw new InvalidOperationException("Invalid Layout!");
        }
    }
}

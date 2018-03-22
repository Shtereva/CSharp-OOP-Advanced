using P05.Logger.Contracts;

namespace P05.Logger.Models
{
    public class XmlLayout : ILayout
    {
        public string MessageFormat => @"<log>
                                        <date>{0}</date>
                                        <level>{1}</level>
                                        <message>{2}</message>
                                        </log>
                                        ";
    }
}

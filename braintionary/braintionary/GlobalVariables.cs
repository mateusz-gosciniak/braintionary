namespace braintionary
{
    public class GlobalVariables
    {
        public static string CurrentWordsList = string.Empty;
        public static string ExtensionWordsList = @".xml";
        public static string PathToList = System.AppDomain.CurrentDomain.BaseDirectory + @"\Słownictwo\";
        public static XmlMaker<Pack> XmlTool = new XmlMaker<Pack>();
        public static Pack Set = new Pack();
        public static bool Randomize = false;
    }
}

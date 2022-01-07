namespace MultiInterfaceDI
{
    public class XTool : ITool
    {
        public string Id => "xtool";

        public string Process(string input)
        {
            return Id + input + "some sfdafs";
        }
    }


}

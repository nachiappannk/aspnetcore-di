namespace MultiInterfaceDI
{
    public class YTool : ITool
    {
        public string Id => "ytool";

        public string Process(string input)
        {
            return Id + input + "some yysts";
        }
    }


}

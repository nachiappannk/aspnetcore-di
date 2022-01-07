namespace MultiInterfaceDI
{
    public class BTool : ITool
    {
        public string Id => "btool";

        public string Process(string input)
        {
            return Id + input + "some b";
        }
    }


}

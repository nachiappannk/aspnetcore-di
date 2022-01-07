namespace MultiInterfaceDI
{
    public class ATool : ITool
    {
        public string Id => "atool";

        public string Process(string input)
        {
            return Id + input + "some asdfaf";
        }
    }


}

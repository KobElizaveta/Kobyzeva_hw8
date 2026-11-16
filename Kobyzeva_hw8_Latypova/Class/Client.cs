
namespace Kobyzeva_hw8_Latypova.Class
{
    public class Client
    {
        public Guid id;
        public string Name;

        public Client(string name)
        {
            id = new Guid();
            Name = name;
        }
        
    }
}

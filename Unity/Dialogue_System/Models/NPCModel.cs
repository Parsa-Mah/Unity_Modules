
namespace PM.Dialogue_System.Models
{
    public class NPCModel
    {
        public int _id;
        public string name;
        public int age;

        public NPCModel(int _id, string name, int age)
        {
            this._id = _id;
            this.name = name;
            this.age = age;
        }
    }
}

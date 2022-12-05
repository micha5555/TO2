namespace Repo.DataAccess
{

    public interface IDataAccess
    {

        public int SaveRecord(object o);
        public object DeleteRecord(int id, string name);
        public object GetRecord(int id, string name);
        public int UpdateRecord(object o);
    }

}
using EmplyoeeCurdApi.Models;

namespace EmplyoeeCurdApi.Repository
{
    public interface IEmpRepository
    {
        public bool AddEmp(Employee employee);
        public bool UpdateEmp(int id ,  Employee employee);
        public bool DeleteEmp(int eid);
        public List<Employee> ShowEmp();
    }
}

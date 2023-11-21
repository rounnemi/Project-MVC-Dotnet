using TP3.Models;

namespace TP3.Services
{
    public interface IMembershipTypeService
    {
        public membershiptype GetByid(string id);
        public ICollection<membershiptype> getAll();
        public membershiptype Add(membershiptype membershiptype);
        public membershiptype Upadate(membershiptype membershiptype);
        public membershiptype Delete(membershiptype membershiptype); 
    }
}

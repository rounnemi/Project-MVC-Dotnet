using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using TP3.Models;

namespace TP3.Services
{
    public class MembershipTypeRepository : IMembershipTypeRepository
    {
        private readonly ApplicationdbContext _db;  
        public MembershipTypeRepository(ApplicationdbContext db)
        {
            _db = db;
        }
        public membershiptype Add(membershiptype membershiptype)
        {
               _db.Memberships.Add(membershiptype);
               _db.SaveChanges();
               return membershiptype;
        }

        public membershiptype Delete(membershiptype membershiptype)
        {
              _db.Memberships.Remove(membershiptype);
              _db.SaveChanges();
              return membershiptype;
        }

        public ICollection<membershiptype> getAll()
        {
            return _db.Memberships.ToList();
        }

        public membershiptype GetByid(string id)
        {
            return _db.Memberships.FirstOrDefault(mt => mt.id == id);
        }

        public membershiptype Upadate(membershiptype membershiptype)
        {
            _db.Memberships.Update(membershiptype);
            _db.SaveChanges();
            return membershiptype;
        }
    }
}

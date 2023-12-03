using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using TP3.Models;

namespace TP3.Services
{
    public class MembershipTypeService : IMembershipTypeService
    {
        private readonly IMembershipTypeRepository _membershipTypeRepository;
        public MembershipTypeService(IMembershipTypeRepository membershipTypeRepository)
        {
            _membershipTypeRepository = membershipTypeRepository;
        }
        public membershiptype Add(membershiptype membershiptype)
        {

            return _membershipTypeRepository.Add(membershiptype);
        }

        public membershiptype Delete(membershiptype membershiptype)
        {

            return _membershipTypeRepository.Delete(membershiptype);
        }

        public ICollection<membershiptype> getAll()
        {
            return _membershipTypeRepository.getAll();
        }

        public membershiptype GetByid(string id)
        {
            return _membershipTypeRepository.GetByid(id);
        }

        public membershiptype Upadate(membershiptype membershiptype)
        {
            
            return _membershipTypeRepository.Upadate(membershiptype);
        }
    }
}

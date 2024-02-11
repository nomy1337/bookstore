using EventManager.DL.Interfaces;
using EventManager.DL.MemoryDatabase;
using EventManager.Models;

namespace EventManager.DL.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly List<Member> _members;

        public MemberRepository()
        {
            _members = InMemoryDatabase.MemberData;
        }

        public Member GetById(int id)
        {
            return _members.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Member member)
        {
            _members.Add(member);
        }

        public void Update(Member member)
        {
            var existingMember = GetById(member.Id);
            if (existingMember != null)
            {
                existingMember.FullName = member.FullName;
                existingMember.Email = member.Email;
                existingMember.PhoneNumber = member.PhoneNumber;
                existingMember.JoinDate = member.JoinDate;
            }
        }

        public void Delete(int id)
        {
            var memberToRemove = GetById(id);
            if (memberToRemove != null)
            {
                _members.Remove(memberToRemove);
            }
        }

        public IEnumerable<Member> GetAll()
        {
            return _members;
        }
    }
}

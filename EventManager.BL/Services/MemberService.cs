using EventManager.BL.Interfaces;
using EventManager.DL.Interfaces;
using EventManager.Models;

namespace EventManager.BL.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public Member GetMemberById(int id)
        {
            return _memberRepository.GetById(id);
        }

        public void AddMember(Member member)
        {
            _memberRepository.Add(member);
        }

        public void UpdateMember(Member member)
        {
            _memberRepository.Update(member);
        }

        public void DeleteMember(int id)
        {
            _memberRepository.Delete(id);
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _memberRepository.GetAll();
        }
    }
}

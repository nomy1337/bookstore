using EventManager.Models;

namespace EventManager.DL.Interfaces
{
    public interface IMemberRepository
    {
        Member GetById(int id);
        void Add(Member member);
        void Update(Member member);
        void Delete(int id);
        IEnumerable<Member> GetAll();
    }
}

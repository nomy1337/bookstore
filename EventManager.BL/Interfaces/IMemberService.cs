using EventManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.BL.Interfaces
{
    public interface IMemberService
    {
        Member GetMemberById(int id);
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int id);
        IEnumerable<Member> GetAllMembers();
    }
}

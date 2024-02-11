using EventManager.BL.Interfaces;
using EventManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("{id}")]
        public IActionResult GetMemberById(int id)
        {
            var member = _memberService.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        public IActionResult AddMember([FromBody] Member member)
        {
            _memberService.AddMember(member);
            return CreatedAtAction(nameof(GetMemberById), new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, [FromBody] Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            _memberService.UpdateMember(member);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            _memberService.DeleteMember(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            var members = _memberService.GetAllMembers();
            return Ok(members);
        }
    }
}

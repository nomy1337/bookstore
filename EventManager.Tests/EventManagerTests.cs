using EventManager.BL.Interfaces;
using EventManager.BL.Services;
using EventManager.Models;
using EventManager.Models.Request;
using Moq;

namespace EventManager.Tests
{
    public class EventManagerServiceTest
    {
        [Fact]
        public void RegisterMemberForEvent_Success()
        {
            var memberId = 1;
            var eventId = 1;
            var mockMemberService = new Mock<IMemberService>();
            mockMemberService.Setup(x => x.GetMemberById(memberId)).Returns(new Member { Id = memberId });
            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(x => x.GetEventById(eventId)).Returns(new Event { Id = eventId });
            var eventManagerService = new EventManagerService(mockMemberService.Object, mockEventService.Object);

            eventManagerService.RegisterMemberForEvent(memberId, eventId);

            mockEventService.Verify(x => x.AddMemberToEvent(It.IsAny<Event>(), It.IsAny<Member>()), Times.Once);
        }

        [Fact]
        public void GetEventsForMember_Success()
        {
            var memberId = 1;
            var member = new Member { Id = memberId };
            var mockMemberService = new Mock<IMemberService>();
            mockMemberService.Setup(x => x.GetMemberById(memberId)).Returns(member);
            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(x => x.GetAllEvents()).Returns(new List<Event>
            {
                new Event { Id = 1, Members = new List<Member> { member } },
                new Event { Id = 2 },
                new Event { Id = 3, Members = new List<Member> { new Member { Id = 2 } } }
            });
            var eventManagerService = new EventManagerService(mockMemberService.Object, mockEventService.Object);

            var response = eventManagerService.GetEventsForMember(new GetEventsForMemberRequest { MemberId = memberId });

            Assert.NotNull(response);
            Assert.Single(response.Events);
            Assert.Equal(1, response.Events[0].Id);
        }

        [Fact]
        public void GetMembersForEvent_Success()
        {
            var eventId = 1;
            var @event = new Event { Id = eventId, Members = new List<Member> { new Member { Id = 1 }, new Member { Id = 2 } } };
            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(x => x.GetEventById(eventId)).Returns(@event);
            var eventManagerService = new EventManagerService(Mock.Of<IMemberService>(), mockEventService.Object);

            var response = eventManagerService.GetMembersForEvent(new GetMembersForEventRequest { EventId = eventId });

            Assert.NotNull(response);
            Assert.Equal(2, response.Members.Count);
        }
    }
}
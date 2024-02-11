using EventManager.Models;

namespace EventManager.DL.MemoryDatabase
{
    public static class InMemoryDatabase
    {
        public static List<Member> MemberData = new List<Member>()
        {
            new Member()
            {
                Id = 1,
                FullName = "John Doe",
                Email = "john@example.com",
                PhoneNumber = "555-1234",
                JoinDate = new DateTime(2023, 5, 15)
            },
            new Member()
            {
                Id = 2,
                FullName = "Jane Smith",
                Email = "jane@example.com",
                PhoneNumber = "555-5678",
                JoinDate = new DateTime(2022, 10, 20)
            },
            new Member()
            {
                Id = 3,
                FullName = "Alex Johnson",
                Email = "alex@example.com",
                PhoneNumber = "555-9876",
                JoinDate = new DateTime(2024, 1, 10)
            },
        };

        public static List<Event> EventData = new List<Event>()
        {
            new Event()
            {
                Id = 1,
                Title = "Programming Workshop",
                Description = "Learn the basics of programming",
                StartTime = new DateTime(2024, 2, 15, 10, 0, 0),
                EndTime = new DateTime(2024, 2, 15, 12, 0, 0),
                Location = "Computer Lab 101",
                Members = new List<Member>()
                {
                    MemberData[1], MemberData[2]
                }
            },
            new Event()
            {
                Id = 2,
                Title = "Web Development Seminar",
                Description = "Explore the latest trends in web development",
                StartTime = new DateTime(2024, 3, 10, 14, 0, 0),
                EndTime = new DateTime(2024, 3, 10, 16, 0, 0),
                Location = "Conference Room A"
            },
            new Event()
            {
                Id = 3,
                Title = "Networking Event",
                Description = "Connect with professionals in the tech industry",
                StartTime = new DateTime(2024, 4, 5, 18, 0, 0),
                EndTime = new DateTime(2024, 4, 5, 20, 0, 0),
                Location = "Lobby",
                Members = new List<Member>()
                {
                    MemberData[0], MemberData[1]
                }
            },
        };
    }
}

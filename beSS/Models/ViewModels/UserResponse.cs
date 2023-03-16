using System;

namespace beSS.Models.ViewModels
{
    public class UserResponse
    {
        public Guid id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
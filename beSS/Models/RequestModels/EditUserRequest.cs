using System;

namespace beSS.Models.RequestModels
{
    public class EditUserRequest
    {
        public Guid id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
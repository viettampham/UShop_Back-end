using System;

namespace beSS.Models.RequestModels
{
    public class EditCategory
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
    }
}
using System;

namespace Sakura.EmailContact.Features.Common
{
    public class BaseEntity
    {
        public BaseEntity()
        {
        }
        public int Id { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now.Date;
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
